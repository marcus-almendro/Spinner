using System;
using System.Collections.Generic;

namespace Spinner.Application.Services.NotaFiscalService.DTO
{
    public class NotaFiscalDTO
    {
        public Guid Id { get; set; }
        public long Cnpj { get; set; }
        public string Empresa { get; set; }
        public List<LinhaNotaFiscalDTO> Linhas { get; set; }
    }
}
