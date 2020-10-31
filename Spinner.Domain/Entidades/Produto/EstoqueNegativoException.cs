using Spinner.Domain.Common;

namespace Spinner.Domain.Entidades.Produto
{
    public class EstoqueNegativoException : DomainException
    {
        public EstoqueNegativoException() : base("O estoque não pode ser negativo")
        {

        }
    }
}