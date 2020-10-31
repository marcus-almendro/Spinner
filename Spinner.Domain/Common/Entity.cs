using System.Collections.Generic;

namespace Spinner.Domain.Common
{
    public abstract class Entity
    {
        public IReadOnlyList<DomainEvent> Events { get => InternalEvents.AsReadOnly(); }
        public void ClearEvents() => InternalEvents.Clear();

        protected List<DomainEvent> InternalEvents = new List<DomainEvent>();
    }
}
