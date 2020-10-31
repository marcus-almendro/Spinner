using Spinner.Application.Common;
using Spinner.Application.Services.ProdutoService.DTO;

namespace Spinner.Application.Services.ProdutoService.Queries
{
    public class FindOneProdutoQuery : IQuery<ProdutoDTO>
    {
        public int Id { get; set; }
    }
}
