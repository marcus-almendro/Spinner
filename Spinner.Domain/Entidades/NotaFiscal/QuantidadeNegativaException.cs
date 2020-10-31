using Spinner.Domain.Common;

namespace Spinner.Domain.Entidades.NotaFiscal
{
    public class QuantidadeNegativaException : DomainException
    {
        public QuantidadeNegativaException() : base("A quantidade não pode ser negativa")
        {

        }
    }
}
