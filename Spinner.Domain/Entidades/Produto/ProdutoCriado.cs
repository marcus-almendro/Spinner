using Spinner.Domain.Common;
using System.Collections.Generic;

namespace Spinner.Domain.Entidades.Produto
{
    internal class ProdutoCriado : DomainEvent
    {
        public ProdutoCriado(int id)
        {
            Id = id;
        }

        public int Id { get; }

        protected override IEnumerable<object> GetAllDomainEventValues()
        {
            yield return Id;
        }
    }
}