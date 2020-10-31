using Spinner.Application.Common;
using Spinner.Application.Services.RelatorioService.DTO;

namespace Spinner.Application.Services.RelatorioService.Queries
{
    public class RelatorioVendasDoMesQuery : IQuery<RelatorioVendasDoMes>
    {
        public int Mes { get; set; }
    }
}
