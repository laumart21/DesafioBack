using DesafioBack.Domain.Domains;
using DesafioBack.Domain.Models;
using DesafioBack.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DesafioBack.DAO
{
    public class TituloDAO
    {
        public void Adiciona(TituloInclusao tituloInclusao)
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    context.Titulos.Add(AddTituloInclusao(tituloInclusao));
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public IList<TituloConsulta> Lista()
        {
            using (var contexto = new ApplicationContext())
            {
                var titulos = contexto.Titulos
                    //.Include(p => p.Parcelas.Where(p => p.Vencimento < DateTime.Now))
                    .Include(p => p.Parcelas)
                    .ToList();

                var listTituloConsulta = new List<TituloConsulta>();

                foreach (var titulo in titulos)
                {
                    var titAtrasado = AddTituloConsulta(titulo);
                    if (titAtrasado.DiasEmAtraso > 0)
                        listTituloConsulta.Add(AddTituloConsulta(titulo));
                }

                return listTituloConsulta;
            }
        }
        public IList<TituloBase> ListaDapper()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
#if DEBUG
            string connection = configuration.GetConnectionString("DebugConnectionString");
#else
            string connection = configuration.GetConnectionString("DockerConnectionString");
#endif
            using (SqlConnection conexao = new SqlConnection(connection))
            {
                return (IList<TituloBase>)conexao.Query<TituloBase>(@"SELECT * FROM dbo.titulo");
            }

        }

        public TituloConsulta BuscaPorId(int id)
        {
            using (var contexto = new ApplicationContext())
            {
                var titulo = contexto.Titulos.Include(p => p.Parcelas)
                    .Where(p => p.Id == id)
                    .FirstOrDefault();


                return AddTituloConsulta(titulo);
            }

        }

        public TituloConsulta AddTituloConsulta(Titulo titulo)
        {
            var tituloConsulta = new TituloConsulta()
            {
                Cpf = titulo.Cpf,
                Id = titulo.Id,
                Juros = titulo.Juros,
                Multa = titulo.Multa,
                Nome = titulo.Nome,
                Numero = titulo.Numero,
                QuantidadeParcelas = titulo.QuantidadeParcelas,
                ValorAtualizado = new TituloCalculoValorAtualizado().Calcular(titulo),
                DiasEmAtraso = Convert.ToInt32(new TituloCalculoDiasEmAtraso().Calcular(titulo)),
                ValorOriginal = new TituloCalculoValorOriginal().Calcular(titulo)
            };
            tituloConsulta.Parcelas = new List<ParcelaConsulta>();

            foreach (var parcela in titulo.Parcelas)
            {
                var parConsulta = new ParcelaConsulta() { Numero = parcela.Numero, Valor = parcela.Valor, Vencimento = parcela.Vencimento };
                tituloConsulta.Parcelas.Add(parConsulta);
            }
            return tituloConsulta;
        }

        public Titulo AddTituloInclusao(TituloInclusao tituloInclusao)
        {
            var titulo = new Titulo()
            {
                Cpf = tituloInclusao.Cpf,
                Juros = tituloInclusao.Juros,
                Multa = tituloInclusao.Multa,
                Nome = tituloInclusao.Nome,
                Numero = tituloInclusao.Numero,
                QuantidadeParcelas = tituloInclusao.Parcelas.Count

            };
            titulo.ValorAtualizado = new TituloCalculoValorAtualizado().Calcular(titulo);
            titulo.Parcelas = new List<Parcela>();

            foreach (var parcela in titulo.Parcelas)
            {
                var parConsulta = new Parcela() { Numero = parcela.Numero, Valor = parcela.Valor, Vencimento = parcela.Vencimento };
                titulo.Parcelas.Add(parConsulta);
            }
            return titulo;
        }
    }
}
