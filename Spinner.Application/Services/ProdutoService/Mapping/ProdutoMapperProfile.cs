using AutoMapper;
using Spinner.Application.Services.ProdutoService.DTO;
using Spinner.Domain.Entidades.Produto;

namespace Spinner.Application.Services.ProdutoService.Mapping
{
    public class ProdutoMapperProfile : Profile
    {
        public ProdutoMapperProfile()
        {
            CreateMap<Produto, ProdutoDTO>();
        }
    }
}
