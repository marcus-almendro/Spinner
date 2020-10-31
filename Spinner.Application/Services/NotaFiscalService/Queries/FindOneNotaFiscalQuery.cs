using Spinner.Application.Common;
using Spinner.Application.Services.NotaFiscalService.DTO;
using System;

namespace Spinner.Application.Services.NotaFiscalService.Queries
{
    public class FindOneNotaFiscalQuery : IQuery<NotaFiscalDTO>
    {
        public Guid Id { get; set; }
    }
}
