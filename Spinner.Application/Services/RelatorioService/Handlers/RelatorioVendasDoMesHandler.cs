using MediatR;
using Spinner.Application.Services.RelatorioService.DAO;
using Spinner.Application.Services.RelatorioService.DTO;
using Spinner.Application.Services.RelatorioService.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Spinner.Application.Services.RelatorioService.Handlers
{
    public class RelatorioVendasDoMesHandler : IRequestHandler<RelatorioVendasDoMesQuery, RelatorioVendasDoMes>
    {
        private readonly IRelatorioDAO _relatorioServiceDAO;

        public RelatorioVendasDoMesHandler(IRelatorioDAO relatorioServiceDAO)
        {
            _relatorioServiceDAO = relatorioServiceDAO;
        }

        public async Task<RelatorioVendasDoMes> Handle(RelatorioVendasDoMesQuery query, CancellationToken cancellationToken)
        {
            return await _relatorioServiceDAO.GetRelatorioVendasDoMes(query.Mes);
        }
    }
}
