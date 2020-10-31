using Spinner.Domain.Entidades.NotaFiscal;
using Spinner.Domain.Entidades.Produto;
using System.Linq;
using System.Threading.Tasks;

namespace Spinner.Domain.Services
{
    public class GerenciadorDePrecos
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IProdutoRepository _produtoRepository;

        public GerenciadorDePrecos(INotaFiscalRepository notaFiscalRepository, IProdutoRepository produtoRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<double> CalculaPrecoVenda(int idProduto)
        {
            var notasFiscais = await _notaFiscalRepository.FindAllByProduct(idProduto);
            var produto = await _produtoRepository.FindOne(idProduto);

            //efetua um cálculo qualquer ;)
            return notasFiscais.SelectMany(l => l.Linhas).Sum(l => l.Preco * l.Quantidade) / produto.Estoque;
        }
    }
}
