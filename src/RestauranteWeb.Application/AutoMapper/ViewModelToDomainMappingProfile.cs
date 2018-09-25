using AutoMapper;
using RestauranteWeb.Application.ViewModels.Pratos;
using RestauranteWeb.Application.ViewModels.Restaurantes;
using RestauranteWeb.Domain.Entities.Pratos;
using RestauranteWeb.Domain.Entities.Restaurantes;

namespace RestauranteWeb.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PratoViewModel, Prato>();
            CreateMap<RestauranteViewModel, Restaurante>();
        }
    }
}