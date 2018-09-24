using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Contracts.Services;
using RestauranteWeb.Domain.Entities.Restaurantes;
using System;

namespace RestauranteWeb.Domain.Services
{
    public class RestauranteService : CadastroBaseService<Restaurante, Guid>, IRestauranteService
    {
        public RestauranteService(IRestauranteRepository repository) : base(repository)
        {
        }
    }
}
