using FluentValidation.Results;
using MediatR;
using Spinner.Application.Services.NotaFiscalService.Commands;
using Spinner.Application.Services.NotaFiscalService.Validation;
using Spinner.Domain.Entidades.NotaFiscal;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Spinner.Application.Services.NotaFiscalService.Handlers
{
    public class CriarNotaFiscalHandler : IRequestHandler<CriarNotaFiscalCommand, (Guid, ValidationResult)>
    {
        private readonly INotaFiscalRepository _repository;
        private readonly IMediator _mediator;

        public CriarNotaFiscalHandler(INotaFiscalRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<(Guid, ValidationResult)> Handle(CriarNotaFiscalCommand cmd, CancellationToken cancellationToken)
        {
            var validationResult = new CriarNotaFiscalValidator().Validate(cmd);

            if (!validationResult.IsValid)
                return (default, validationResult);

            var id = Guid.NewGuid();
            var nf = new NotaFiscal(id, cmd.Cnpj, cmd.Empresa);
            cmd.Linhas.ForEach(linha => nf.AdicionarProduto(linha.IdProduto, linha.Quantidade, linha.Preco));

            await _repository.Save(nf);

            foreach (var evt in nf.Events)
                await _mediator.Publish(evt);

            return (id, new ValidationResult());
        }
    }
}
