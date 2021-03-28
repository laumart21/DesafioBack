using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBack.Domain.Domains
{
    public class TituloBase
    {
        public long Numero { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
    }
}
