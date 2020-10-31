using MediatR;
using System;
using System.Collections.Generic;

namespace Spinner.Domain.Common
{
    public abstract class DomainEvent : ValueObject, INotification
    {
        public DateTimeOffset CreationDate { get; } = Clock.UtcNow;

        protected abstract IEnumerable<object> GetAllDomainEventValues();

        protected override IEnumerable<object> GetAllValues()
        {
            yield return CreationDate;
            foreach (var value in GetAllDomainEventValues())
                yield return value;
        }
    }
}
