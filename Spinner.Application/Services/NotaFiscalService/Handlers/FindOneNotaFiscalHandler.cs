using AutoMapper;
using MediatR;
using Spinner.Application.Services.NotaFiscalService.DTO;
using Spinner.Application.Services.NotaFiscalService.Queries;
using Spinner.Domain.Entidades.NotaFiscal;
using System.Threading;
using System.Threading.Tasks;

namespace Spinner.Application.Services.NotaFiscalService.Handlers
{
    public class FindOneNotaFiscalHandler : IRequestHandler<FindOneNotaFiscalQuery, NotaFiscalDTO>
    {
        private readonly INotaFiscalRepository _repository;
        private readonly IMapper _mapper;

        public FindOneNotaFiscalHandler(INotaFiscalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NotaFiscalDTO> Handle(FindOneNotaFiscalQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<NotaFiscalDTO>(await _repository.FindOne(query.Id));
        }
    }
}
