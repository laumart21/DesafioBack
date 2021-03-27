using DesafioBack.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBack.Repository
{
    public interface IRepository
    {
        IEnumerable<Titulo> Titulos { get; }
    }
}
