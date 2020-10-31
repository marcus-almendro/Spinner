using FluentValidation;
using Spinner.Application.Services.ProdutoService.Commands;

namespace Spinner.Application.Services.ProdutoService.Validation
{
    public class CriarProdutoValidator : AbstractValidator<CriarProdutoCommand>
    {
        public CriarProdutoValidator()
        {
            RuleFor(c => c.Nome).Length(1, 20);
            RuleFor(c => c.Estoque).GreaterThan(0);
        }
    }
}
