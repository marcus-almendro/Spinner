using Dapper;
using Newtonsoft.Json;
using Spinner.Domain.Common;
using System.Data;
using System.Threading.Tasks;

namespace Spinner.Infrastructure.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly IDbConnection _dbConnection;

        public EventStoreRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Save(DomainEvent evt)
        {
            await _dbConnection.ExecuteAsync(@"
                    insert into Eventos (CreationDate, EventType, Blob) 
                    values (@CreationDate, @EventType, @Blob)",
                new
                {
                    evt.CreationDate,
                    EventType = evt.GetType().Name,
                    Blob = JsonConvert.SerializeObject(evt)
                });
        }
    }
}
