using DesafioBack.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBack.Repository
{
    public class TituloRepository : IRepository
    {
        private ApplicationContext _context;
        public TituloRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Titulo> Titulos => _context.Titulos;
    }
}
