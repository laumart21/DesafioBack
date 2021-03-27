using DesafioBack.Domain.Domains;

namespace DesafioBack.Domain.Models
{
    public interface ICalculo
    {
        decimal Calcular(Titulo titulo);
    }
}