using Dapper;
using Spinner.Application.Services.RelatorioService.DAO;
using Spinner.Application.Services.RelatorioService.DTO;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Spinner.Infrastructure.DAOs
{
    public class RelatorioDAOSqlite : IRelatorioDAO
    {
        private readonly IDbConnection _dbConnection;

        public RelatorioDAOSqlite(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<RelatorioVendasDoMes> GetRelatorioVendasDoMes(int mes)
        {
            var r = await _dbConnection.QueryAsync<LinhaVendaDoMes>("select ...");
            return new RelatorioVendasDoMes { Linhas = r.ToList() };
        }
    }
}
