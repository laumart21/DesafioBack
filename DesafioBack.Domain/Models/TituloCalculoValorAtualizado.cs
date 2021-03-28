using DesafioBack.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBack.Domain.Models
{
    public class TituloCalculoValorAtualizado : ICalculo
    {
        public decimal Calcular(Titulo titulo)
        {
            var juros = new TituloCalculoJuros().Calcular(titulo);
            var multa = new TituloCalculoMulta().Calcular(titulo);
            var original = new TituloCalculoValorOriginal().Calcular(titulo);

            return original + juros + multa;
        }
    }
}
