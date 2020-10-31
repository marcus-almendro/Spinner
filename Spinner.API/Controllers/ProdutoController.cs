using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spinner.API.Extensions;
using Spinner.Application.Services.ProdutoService.Commands;
using Spinner.Application.Services.ProdutoService.Queries;
using System.Threading.Tasks;

namespace Spinner.API.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarProdutoCommand cmd)
        {
            var (id, validationResult) = await _mediator.Send(cmd);

            if (validationResult.IsValid)
                return CreatedAtRoute("GetOneProduto", new { id }, id);
            else
                return BadRequest(validationResult.ToDTO());
        }

        [HttpGet("{id}", Name = "GetOneProduto")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var produto = await _mediator.Send(new FindOneProdutoQuery { Id = id });

            if (produto == null)
                return NotFound();
            else
                return Ok(produto);
        }
    }
}
