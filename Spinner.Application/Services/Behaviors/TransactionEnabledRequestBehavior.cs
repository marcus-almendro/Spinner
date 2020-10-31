using MediatR;
using Spinner.Application.Common;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Spinner.Application.Services.Behaviors
{
    public class TransactionEnabledRequestBehavior<Req, Res> : IPipelineBehavior<Req, Res>
    {
        private readonly IDbConnection _connection;

        public TransactionEnabledRequestBehavior(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Res> Handle(Req request, CancellationToken cancellationToken, RequestHandlerDelegate<Res> next)
        {
            if (request.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICommand<>)))
            {
                using (var t = _connection.BeginTransaction())
                {
                    var result = await next();
                    t.Commit();
                    return result;
                }
            }

            if (request.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IQuery<>)))
            {
                return await next();
            }

            throw new NotSupportedException();
        }
    }
}
