using DesafioBack.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBack.Domain.Models
{
    public class TituloCalculoJuros : ICalculo
    {
        public TituloCalculoJuros()
        {
        }
        public decimal Calcular(Titulo titulo)
        {
            decimal juros = titulo.Parcelas.Select((p) =>
            {
                return Math.Round(((titulo.Juros / 30) * ((int)(DateTime.Now - p.Vencimento).TotalDays) * p.Valor) / 100, 2);
            }).Sum();

            return juros;
        }
    }
}
