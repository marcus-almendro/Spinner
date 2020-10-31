using System.Threading.Tasks;

namespace Spinner.Domain.Common
{
    public interface IEventStoreRepository
    {
        Task Save(DomainEvent @event);
    }
}
