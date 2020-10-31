using Spinner.Domain.Common;
using System.Collections.Generic;

namespace Spinner.Domain.Entidades.NotaFiscal
{
    public class LinhaNotaFiscal : ValueObject
    {
        public LinhaNotaFiscal(int numeroLinha, int idProduto, int quantidade, double preco)
        {
            NumeroLinha = numeroLinha;
            IdProduto = idProduto;
            Quantidade = quantidade;
            Preco = preco;
        }

        public int NumeroLinha { get; }
        public int IdProduto { get; }
        public int Quantidade { get; }
        public double Preco { get; }

        public double Valor => Quantidade * Preco;

        protected override IEnumerable<object> GetAllValues()
        {
            yield return IdProduto;
            yield return Quantidade;
            yield return Preco;
        }
    }
}
