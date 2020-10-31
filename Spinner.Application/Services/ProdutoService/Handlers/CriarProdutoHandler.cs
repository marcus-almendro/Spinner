using FluentValidation.Results;
using MediatR;
using Spinner.Application.Services.ProdutoService.Commands;
using Spinner.Application.Services.ProdutoService.Validation;
using Spinner.Domain.Entidades.Produto;
using System.Threading;
using System.Threading.Tasks;

namespace Spinner.Application.Services.ProdutoService.Handlers
{
    public class CriarProdutoHandler : IRequestHandler<CriarProdutoCommand, (int, ValidationResult)>
    {
        private readonly IProdutoRepository _repository;
        private readonly IMediator _mediator;

        public CriarProdutoHandler(IProdutoRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<(int, ValidationResult)> Handle(CriarProdutoCommand criarProduto, CancellationToken cancellationToken)
        {
            var validationResult = new CriarProdutoValidator().Validate(criarProduto);

            if (!validationResult.IsValid)
                return (default, validationResult);

            var id = await _repository.NextId();
            var produto = new Produto(id, criarProduto.Nome, criarProduto.Estoque);

            await _repository.Save(produto);

            foreach (var evt in produto.Events)
                await _mediator.Publish(evt);

            return (id, new ValidationResult());
        }
    }
}
