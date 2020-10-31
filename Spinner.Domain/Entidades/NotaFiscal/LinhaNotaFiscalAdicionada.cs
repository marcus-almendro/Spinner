using Spinner.Domain.Common;
using System;
using System.Collections.Generic;

namespace Spinner.Domain.Entidades.NotaFiscal
{
    public class LinhaNotaFiscalAdicionada : DomainEvent
    {
        public LinhaNotaFiscalAdicionada(Guid idNotaFiscal, LinhaNotaFiscal linha)
        {
            IdNotaFiscal = idNotaFiscal;
            Linha = linha;
        }

        public Guid IdNotaFiscal { get; }
        public LinhaNotaFiscal Linha { get; }

        protected override IEnumerable<object> GetAllDomainEventValues()
        {
            yield return IdNotaFiscal;
            yield return Linha;
        }
    }
}
