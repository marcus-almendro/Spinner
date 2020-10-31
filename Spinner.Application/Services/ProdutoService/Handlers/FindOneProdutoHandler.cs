using AutoMapper;
using MediatR;
using Spinner.Application.Services.ProdutoService.DTO;
using Spinner.Application.Services.ProdutoService.Queries;
using Spinner.Domain.Entidades.Produto;
using System.Threading;
using System.Threading.Tasks;

namespace Spinner.Application.Services.ProdutoService.Handlers
{
    public class FindOneProdutoHandler : IRequestHandler<FindOneProdutoQuery, ProdutoDTO>
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public FindOneProdutoHandler(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> Handle(FindOneProdutoQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProdutoDTO>(await _repository.FindOne(query.Id));
        }
    }
}
