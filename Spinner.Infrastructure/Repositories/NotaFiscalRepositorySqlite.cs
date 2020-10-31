using Dapper;
using Spinner.Domain.Entidades.NotaFiscal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Spinner.Infrastructure.Repositories
{
    public class NotaFiscalRepositorySqlite : INotaFiscalRepository
    {
        private readonly IDbConnection _dbConnection;

        public NotaFiscalRepositorySqlite(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<NotaFiscal>> FindAllByProduct(int idProduto)
        {
            var nfs = await _dbConnection.QueryAsync(@"
                select * 
                from NotaFiscal nf 
                inner join NotaFiscalLinhas l on nf.Id = l.IdNotaFiscal
                where l.IdProduto = @idProduto", new { idProduto });

            if (!nfs.Any())
                return null;

            var notasFiscais = nfs.GroupBy(nf => nf.Id).Select(g =>
                new NotaFiscal(
                    g.Key,
                    g.First().Cnpj,
                    g.First().Empresa,
                    g.Select(l => new LinhaNotaFiscal(l.NumeroLinha, l.IdProduto, l.Quantidade, l.Preco)).ToList())
            ).ToList();

            return notasFiscais;
        }

        public async Task<NotaFiscal> FindOne(Guid id)
        {
            var nf = await _dbConnection.QueryAsync(@"
                select * 
                from NotaFiscal nf 
                inner join NotaFiscalLinhas l on nf.id = l.idNotaFiscal 
                where nf.id = @id", new { id });

            if (!nf.Any())
                return null;

            var notaFiscal = new NotaFiscal(
                nf.First().Id,
                nf.First().CNPJ,
                nf.First().Empresa,
                nf.Select(l => new LinhaNotaFiscal(l.NumeroLinha, l.IdProduto, l.Quantidade, l.Preco)).ToList());

            return notaFiscal;
        }

        public async Task Save(NotaFiscal notaFiscal)
        {
            await _dbConnection.ExecuteAsync("insert into NotaFiscal (Id, Cnpj, Empresa) values (@Id, @Cnpj, @Empresa)", notaFiscal);

            foreach (var linha in notaFiscal.Linhas)
            {
                await _dbConnection.ExecuteAsync(@"
                    insert into NotaFiscalLinhas (IdNotaFiscal, NumeroLinha, IdProduto, Quantidade, Preco) 
                    values (@IdNotaFiscal, @NumeroLinha, @IdProduto, @Quantidade, @Preco)",
                    new
                    {
                        IdNotaFiscal = notaFiscal.Id,
                        linha.NumeroLinha,
                        linha.IdProduto,
                        linha.Quantidade,
                        linha.Preco
                    });
            }
        }
    }
}
