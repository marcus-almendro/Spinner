using MediatR;
using Moq;
using Spinner.Application.Services.NotaFiscalService.Commands;
using Spinner.Application.Services.NotaFiscalService.DTO;
using Spinner.Application.Services.NotaFiscalService.Handlers;
using Spinner.Domain.Common;
using Spinner.Domain.Entidades.NotaFiscal;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Spinner.Tests.UnitTests.Application
{
    public class NotaFiscalServiceTests
    {
        [Fact]
        public async Task ServicoDevePublicarEventoNotaFiscalCriada()
        {
            Clock.UseTestClock = true;
            var repo = new Mock<INotaFiscalRepository>();
            var mediator = new Mock<IMediator>();
            var cmd = new CriarNotaFiscalCommand
            {
                Cnpj = 123,
                Empresa = "text",
                Linhas = new List<LinhaNotaFiscalDTO>
                {
                    new LinhaNotaFiscalDTO{ IdProduto = 1, Preco = 10, Quantidade = 1}
                }
            };
            var nfs = new CriarNotaFiscalHandler(repo.Object, mediator.Object);

            var (id, validationResult) = await nfs.Handle(cmd, new CancellationToken());

            mediator.Verify(m => m.Publish<DomainEvent>(new NotaFiscalCriada(id), default));
        }
    }
}
