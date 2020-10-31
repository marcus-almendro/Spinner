using MediatR;
using Spinner.Domain.Entidades.NotaFiscal;
using Spinner.Domain.Entidades.Produto;
using System.Threading;
using System.Threading.Tasks;

namespace Spinner.Application.Services.ProdutoService.Handlers
{
    public class LinhaNotaFiscalAdicionadaHandler : INotificationHandler<LinhaNotaFiscalAdicionada>
    {
        private readonly IProdutoRepository _repository;
        private readonly IMediator _mediator;

        public LinhaNotaFiscalAdicionadaHandler(IProdutoRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task Handle(LinhaNotaFiscalAdicionada linha, CancellationToken cancellationToken)
        {
            var produto = await _repository.FindOne(linha.Linha.IdProduto);

            produto.RegistrarVenda(linha.Linha.Quantidade);

            foreach (var evt in produto.Events)
                await _mediator.Publish(evt);

            await _repository.Save(produto);
        }
    }
}
