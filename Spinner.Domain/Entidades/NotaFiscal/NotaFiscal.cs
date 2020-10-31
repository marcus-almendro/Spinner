using Spinner.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Spinner.Domain.Entidades.NotaFiscal
{
    public class NotaFiscal : Entity
    {
        private readonly List<LinhaNotaFiscal> _linhas;

        public NotaFiscal(Guid id, long cnpj, string empresa)
        {
            if (string.IsNullOrEmpty(empresa))
                throw new ArgumentException(nameof(empresa));

            if (cnpj == 0)
                throw new ArgumentException(nameof(cnpj));

            Id = id;
            Cnpj = cnpj;
            Empresa = empresa;
            _linhas = new List<LinhaNotaFiscal>();

            InternalEvents.Add(new NotaFiscalCriada(id));
        }

        // para o ORM
        internal NotaFiscal(Guid id, long cnpj, string empresa, List<LinhaNotaFiscal> linhas)
        {
            Id = id;
            Cnpj = cnpj;
            Empresa = empresa;
            _linhas = linhas;
        }

        public Guid Id { get; }
        public long Cnpj { get; }
        public string Empresa { get; }
        public ReadOnlyCollection<LinhaNotaFiscal> Linhas => _linhas.AsReadOnly();

        public double ValorTotal => Linhas.Sum(linha => linha.Valor);

        public void AdicionarProduto(int idProduto, int quantidade, double preco)
        {
            if (quantidade <= 0)
                throw new QuantidadeNegativaException();

            if (preco <= 0)
                throw new PrecoNegativoException();

            var linha = new LinhaNotaFiscal(Linhas.Count + 1, idProduto, quantidade, preco);

            _linhas.Add(linha);

            InternalEvents.Add(new LinhaNotaFiscalAdicionada(Id, linha));
        }
    }
}
