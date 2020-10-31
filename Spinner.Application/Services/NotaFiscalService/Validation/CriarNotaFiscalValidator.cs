using FluentValidation;
using Spinner.Application.Services.NotaFiscalService.Commands;

namespace Spinner.Application.Services.NotaFiscalService.Validation
{
    public class CriarNotaFiscalValidator : AbstractValidator<CriarNotaFiscalCommand>
    {
        public CriarNotaFiscalValidator()
        {
            RuleFor(c => c.Cnpj).GreaterThan(0);
            RuleFor(c => c.Empresa).NotEmpty().Length(1, 50);
            RuleFor(c => c.Linhas).NotEmpty();
            //TODO: cobrir mais DomainExceptions
        }
    }
}
