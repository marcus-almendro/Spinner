using FluentValidation.Results;
using Spinner.Application.Common;

namespace Spinner.Application.Services.ProdutoService.Commands
{
    public class CriarProdutoCommand : ICommand<(int, ValidationResult)>
    {
        public string Nome { get; set; }
        public int Estoque { get; set; }
    }
}
