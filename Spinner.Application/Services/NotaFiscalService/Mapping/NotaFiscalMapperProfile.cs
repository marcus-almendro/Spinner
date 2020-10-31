using AutoMapper;
using Spinner.Application.Services.NotaFiscalService.DTO;
using Spinner.Domain.Entidades.NotaFiscal;

namespace Spinner.Application.Services.NotaFiscalService.Mapping
{
    public class NotaFiscalMapperProfile : Profile
    {
        public NotaFiscalMapperProfile()
        {
            CreateMap<NotaFiscal, NotaFiscalDTO>();
            CreateMap<LinhaNotaFiscal, LinhaNotaFiscalDTO>();
        }
    }
}
