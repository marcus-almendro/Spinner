using System.Threading.Tasks;

namespace Spinner.Domain.Entidades.Produto
{
    public interface IProdutoRepository
    {
        Task<Produto> FindOne(int id);
        Task Save(Produto produto);
        Task<int> NextId();
    }
}
