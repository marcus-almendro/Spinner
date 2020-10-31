using Dapper;
using Spinner.Domain.Entidades.Produto;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Spinner.Infrastructure.Repositories
{
    public class ProdutoRepositorySqlite : IProdutoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProdutoRepositorySqlite(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Produto> FindOne(int id)
        {
            var p = await _dbConnection.QueryAsync<Produto>("select * from Produto where id = @id", new { id });
            return p.FirstOrDefault();
        }

        public async Task<int> NextId()
        {
            var nextId = await _dbConnection.QueryAsync<int>("select count(id) + 1 from Produto");
            return nextId.First();
        }

        public async Task Save(Produto produto)
        {
            await _dbConnection.ExecuteAsync(@"insert into Produto (Id, Nome, Estoque) values (@Id, @Nome, @Estoque) 
                ON CONFLICT(Id) DO UPDATE SET Nome = excluded.Nome, Estoque = excluded.Estoque", produto);
        }
    }
}
