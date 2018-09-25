using RestauranteWeb.Application.Contracts;
using RestauranteWeb.Application.ViewModels.Restaurantes;
using RestauranteWeb.Domain.Contracts.Services;
using RestauranteWeb.Domain.Entities.Restaurantes;
using System;

namespace RestauranteWeb.Application.AppServices
{
    public class RestauranteAppService : AppCadastroServiceBase<Restaurante, RestauranteViewModel, Guid>, IRestauranteAppService
    {
        public RestauranteAppService(IRestauranteService serviceBase) : base(serviceBase)
        {
        }
    }
}
