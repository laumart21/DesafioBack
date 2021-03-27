using System;

namespace DesafioBack.Domain.Domains
{
    public class Parcela
    {
        public int Id { get; set; }
        public int TituloId { get; set; }
        public Titulo Titulo { get; set; }
        public int Numero { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
    }
}
