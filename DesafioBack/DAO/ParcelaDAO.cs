using DesafioBack.Domain.Domains;
using DesafioBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBack.DAO
{
    public class ParcelaDAO
    {
        public void Adiciona(Parcela parcela)
        {
            using (var context = new ApplicationContext())
            {
                context.Parcelas.Add(parcela);
                context.SaveChanges();
            }
        }

        public IList<Parcela> Lista()
        {
            using (var contexto = new ApplicationContext())
            {
                return contexto.Parcelas.ToList();
            }
        }

        public Parcela BuscaPorId(int id)
        {
            using (var contexto = new ApplicationContext())
            {
                return contexto.Parcelas.Find(id);
            }
        }
    }
}
