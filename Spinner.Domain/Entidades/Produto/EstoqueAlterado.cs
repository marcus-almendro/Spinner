using Spinner.Domain.Common;
using System.Collections.Generic;

namespace Spinner.Domain.Entidades.Produto
{
    public class EstoqueAlterado : DomainEvent
    {
        public EstoqueAlterado(int idProduto, int novoEstoque)
        {
            IdProduto = idProduto;
            NovoEstoque = novoEstoque;
        }

        public int IdProduto { get; }
        public int NovoEstoque { get; }

        protected override IEnumerable<object> GetAllDomainEventValues()
        {
            yield return IdProduto;
            yield return NovoEstoque;
        }
    }
}