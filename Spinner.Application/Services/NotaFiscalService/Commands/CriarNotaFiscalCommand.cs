using FluentValidation.Results;
using Spinner.Application.Common;
using Spinner.Application.Services.NotaFiscalService.DTO;
using System;
using System.Collections.Generic;

namespace Spinner.Application.Services.NotaFiscalService.Commands
{
    public class CriarNotaFiscalCommand : ICommand<(Guid, ValidationResult)>
    {
        public long Cnpj { get; set; }
        public string Empresa { get; set; }
        public List<LinhaNotaFiscalDTO> Linhas { get; set; }
    }
}
