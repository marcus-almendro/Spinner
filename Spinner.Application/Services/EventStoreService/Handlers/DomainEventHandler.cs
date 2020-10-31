using MediatR;
using Spinner.Domain.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Spinner.Application.Services.EventStoreService.Handlers
{
    public class DomainEventHandler<T> : INotificationHandler<T> where T : DomainEvent
    {
        private readonly IEventStoreRepository _repository;

        public DomainEventHandler(IEventStoreRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(T evt, CancellationToken cancellationToken)
        {
            return _repository.Save(evt);
        }
    }
}
