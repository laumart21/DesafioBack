using System.Collections.Generic;

namespace DesafioBack.Domain.Domains
{
    public class Titulo
    {

        public int Id { get; set; }

        public long Numero { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }

        public ICollection<Parcela> Parcelas { get; set; }

    }
}
