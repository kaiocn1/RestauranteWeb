using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Entities.Restaurantes;
using System;

namespace RestauranteWeb.Infra.Data.Repositories
{
    public class RestauranteRepository : BaseCadastroRepository<Restaurante, Guid>, IRestauranteRepository
    {
    }
}
