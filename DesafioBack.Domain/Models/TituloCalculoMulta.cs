using DesafioBack.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBack.Domain.Models
{
    public class TituloCalculoMulta : ICalculo
    {
        public TituloCalculoMulta()
        {
        }

        public decimal Calcular(Titulo titulo)
        {
            return new TituloCalculoValorOriginal().Calcular(titulo) * titulo.Multa / 100;
        }
    }
}
