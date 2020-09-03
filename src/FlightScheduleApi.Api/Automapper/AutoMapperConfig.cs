using AutoMapper;
using FlightScheduleApi.Api.ViewModels;
using FlightScheduleApi.Business.Models;

namespace FlightScheduleApi.Api.AutoMapper
{
    //--- A Profile diz que essa é uma classe de um perfil de mapeamento
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
