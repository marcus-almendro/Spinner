using Spinner.Domain.Common;
using System;
using System.Collections.Generic;

namespace Spinner.Domain.Entidades.NotaFiscal
{
    public class NotaFiscalCriada : DomainEvent
    {
        public NotaFiscalCriada(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        protected override IEnumerable<object> GetAllDomainEventValues()
        {
            yield return Id;
        }
    }
}