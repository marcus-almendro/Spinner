using AutoMapper;
using MediatR;
using Spinner.Application.Services.NotaFiscalService.DTO;
using Spinner.Application.Services.NotaFiscalService.Queries;
using Spinner.Domain.Entidades.NotaFiscal;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Spinner.Application.Services.NotaFiscalService.Handlers
{
    public class FindAllNotasFiscaisByIdProdutoHandler : IRequestHandler<FindAllNotasFiscaisByIdProdutoQuery, IEnumerable<NotaFiscalDTO>>
    {
        private readonly INotaFiscalRepository _repository;
        private readonly IMapper _mapper;

        public FindAllNotasFiscaisByIdProdutoHandler(INotaFiscalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotaFiscalDTO>> Handle(FindAllNotasFiscaisByIdProdutoQuery query, CancellationToken cancellationToken)
        {
            var lista = await _repository.FindAllByProduct(query.IdProduto);
            return lista.Select(l => _mapper.Map<NotaFiscalDTO>(l));
        }
    }
}
