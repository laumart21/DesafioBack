using DesafioBack.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBack.Repository
{
    public class PopulaTitulo
    {
        public Titulo titulo { get; }
        public List<Titulo> listTitulo { get; }
        public PopulaTitulo()
        {
            listTitulo = new List<Titulo>();
            titulo = new Titulo()
            {
                Cpf = "29644455509",
                Juros = 1,
                Multa = 2,
                Parcelas = new List<Parcela>()
                {
                    new Parcela(){Numero = 10, Vencimento = new DateTime(2020, 10, 10), Valor = 120},
                    new Parcela(){Numero = 11, Vencimento = new DateTime(2020, 11, 10), Valor = 120},
                    new Parcela(){Numero = 10, Vencimento = new DateTime(2020, 12, 10), Valor = 120}
                }
            };


            listTitulo.Add(titulo);
            listTitulo.Add(new Titulo()
            {
                Cpf = "11111111111",
                Juros = 2,
                Multa = 3,
                Parcelas = new List<Parcela>()
                {
                    new Parcela(){Numero = 1, Vencimento = new DateTime(2020, 1, 10), Valor = 210},
                    new Parcela(){Numero = 2, Vencimento = new DateTime(2020, 2, 10), Valor = 210},
                    new Parcela(){Numero = 3, Vencimento = new DateTime(2020, 3, 10), Valor = 210}
                }
            });

            listTitulo.Add(new Titulo()
            {
                Cpf = "22222222222",
                Juros = 2,
                Multa = 2.5M,
                Parcelas = new List<Parcela>()
                {
                    new Parcela(){Numero = 1, Vencimento = new DateTime(2020, 4, 10), Valor = 300},
                    new Parcela(){Numero = 2, Vencimento = new DateTime(2020, 5, 10), Valor = 260},
                    new Parcela(){Numero = 3, Vencimento = new DateTime(2020, 6, 10), Valor = 210}
                }
            });
        }
    }
}
