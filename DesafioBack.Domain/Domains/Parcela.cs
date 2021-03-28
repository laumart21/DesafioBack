using System;

namespace DesafioBack.Domain.Domains
{
    public class Parcela : ParcelaInclusao
    {
        public int Id { get; set; }
        public int TituloId { get; set; }
        
        public Titulo Titulo { get; set; }
    }
}
