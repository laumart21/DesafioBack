using DesafioBack.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBack.Domain.Models
{
    public class TituloCalculoDiasEmAtraso : ICalculo
    {
        public decimal Calcular(Titulo titulo)
        {
            var minVencimento = titulo.Parcelas.Min(p => p.Vencimento);
            return Convert.ToDecimal((DateTime.Now - minVencimento).TotalDays);
        }
    }
}
