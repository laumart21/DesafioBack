using DesafioBack.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBack.Domain.Models
{
    public class TituloCalculoValorOriginal : ICalculo
    {
        public TituloCalculoValorOriginal()
        {
        }

        public decimal Calcular(Titulo titulo)
        {
            return titulo.Parcelas.Select(p => p.Valor).Sum();
        }

    }
}
