using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBack.Domain.Domains
{
    public class TituloConsulta : TituloBase
    {
        public int Id { get; set; }
        public int QuantidadeParcelas { get; set; }
        public decimal ValorAtualizado { get; set; }
        public decimal ValorOriginal { get; set; }
        public int DiasEmAtraso { get; set; }
        public List<ParcelaConsulta> Parcelas { get; set; }
    }
}
