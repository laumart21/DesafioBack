using DesafioBack.Domain.Domains;
using DesafioBack.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBack.DAO
{
    public class TituloDAO
    {
        public void Adiciona(Titulo titulo)
        {
            using (var context = new ApplicationContext())
            {
                context.Titulos.Add(titulo);
                context.SaveChanges();
            }
        }

        public IList<Titulo> Lista()
        {
            using (var contexto = new ApplicationContext())
            {
                return contexto.Titulos.Include("Parcela").ToList();
            }
        }

        public Titulo BuscaPorId(int id)
        {
            using (var contexto = new ApplicationContext())
            {
                return contexto.Titulos.Include("Parcela")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }
    }
}
