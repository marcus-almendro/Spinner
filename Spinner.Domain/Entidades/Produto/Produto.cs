using Spinner.Domain.Common;
using System;

namespace Spinner.Domain.Entidades.Produto
{
    public class Produto : Entity
    {
        public Produto(int id, string nome, int estoque)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException(nameof(nome));

            Id = id;
            Nome = nome;
            Estoque = estoque;

            if (estoque < 0)
                throw new EstoqueNegativoException();

            InternalEvents.Add(new ProdutoCriado(id));
        }

        //para o ORM
        internal Produto() { }

        public int Id { get; }
        public string Nome { get; }
        public int Estoque { get; private set; }

        public void RegistrarVenda(int quantidade)
        {
            if (Estoque - quantidade < 0)
                throw new EstoqueNegativoException();

            Estoque -= quantidade;

            InternalEvents.Add(new EstoqueAlterado(Id, Estoque));
        }
    }
}
