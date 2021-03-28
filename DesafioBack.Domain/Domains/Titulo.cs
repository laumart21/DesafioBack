using System.Collections.Generic;

namespace DesafioBack.Domain.Domains
{
    public class Titulo : TituloBase
    {
        public int Id { get; set; }
        public int QuantidadeParcelas { get; set; }
        public decimal ValorAtualizado { get; set; }

        public List<Parcela> Parcelas { get; set; }
    }
}
