using Spinner.Domain.Common;

namespace Spinner.Domain.Entidades.NotaFiscal
{
    public class PrecoNegativoException : DomainException
    {
        public PrecoNegativoException() : base("O preço não pode ser negativo")
        {

        }
    }
}
