using Spinner.Application.Services.RelatorioService.DTO;
using System.Threading.Tasks;

namespace Spinner.Application.Services.RelatorioService.DAO
{
    public interface IRelatorioDAO
    {
        Task<RelatorioVendasDoMes> GetRelatorioVendasDoMes(int mes);
    }
}
