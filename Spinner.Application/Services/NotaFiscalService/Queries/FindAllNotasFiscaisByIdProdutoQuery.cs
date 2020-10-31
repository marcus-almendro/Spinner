using Spinner.Application.Common;
using Spinner.Application.Services.NotaFiscalService.DTO;
using System.Collections.Generic;

namespace Spinner.Application.Services.NotaFiscalService.Queries
{
    public class FindAllNotasFiscaisByIdProdutoQuery : IQuery<IEnumerable<NotaFiscalDTO>>
    {
        public int IdProduto { get; set; }
    }
}
