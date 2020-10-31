using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spinner.Domain.Entidades.NotaFiscal
{
    public interface INotaFiscalRepository
    {
        Task<NotaFiscal> FindOne(Guid id);
        Task Save(NotaFiscal notaFiscal);
        Task<IEnumerable<NotaFiscal>> FindAllByProduct(int idProduto);
    }
}
