using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spinner.API.Extensions;
using Spinner.Application.Services.NotaFiscalService.Commands;
using Spinner.Application.Services.NotaFiscalService.Queries;
using System;
using System.Threading.Tasks;

namespace Spinner.API.Controllers
{
    [ApiController]
    [Route("notas_fiscais")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotaFiscalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarNotaFiscalCommand cmd)
        {
            var (id, validationResult) = await _mediator.Send(cmd);

            if (validationResult.IsValid)
                return CreatedAtRoute("GetOneNotaFiscal", new { id }, id);
            else
                return BadRequest(validationResult.ToDTO());
        }

        [HttpGet("{id}", Name = "GetOneNotaFiscal")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            var nf = await _mediator.Send(new FindOneNotaFiscalQuery { Id = id });

            if (nf == null)
                return NotFound();
            else
                return Ok(nf);
        }

        [HttpGet("/produtos/{id}/notas_fiscais")]
        public async Task<IActionResult> GetByProductId([FromRoute] int id)
        {
            var nfs = await _mediator.Send(new FindAllNotasFiscaisByIdProdutoQuery { IdProduto = id });

            if (nfs == null)
                return NotFound();
            else
                return Ok(nfs);
        }
    }
}
