using Spinner.Domain.Common;
using Spinner.Domain.Entidades.NotaFiscal;
using System;
using System.Linq;
using Xunit;

namespace Spinner.Tests.UnitTests.Domain
{
    public class NotaFiscalTests
    {
        [Fact]
        public void NotaFiscalDevePublicarEventoDeCriacao()
        {
            Clock.UseTestClock = true;

            var nf = new NotaFiscal(Guid.Empty, 1, "text");

            var nfCriada = nf.Events.OfType<NotaFiscalCriada>().FirstOrDefault();

            Assert.NotNull(nfCriada);
            Assert.Equal(new NotaFiscalCriada(nf.Id), nfCriada);
        }

        [Fact]
        public void NotaFiscalNaoPodeReceberValorNegativoDeQuantidade()
        {
            var nf = new NotaFiscal(Guid.Empty, 1, "text");

            Assert.Throws<QuantidadeNegativaException>(() => nf.AdicionarProduto(0, -1, 0));
        }

        [Fact]
        public void NotaFiscalDeveSumarizarCorretamente()
        {
            var nf = new NotaFiscal(Guid.Empty, 1, "text");

            nf.AdicionarProduto(0, 1, 10);
            nf.AdicionarProduto(0, 1, 20);

            Assert.Equal(30, nf.ValorTotal);
        }
    }
}
