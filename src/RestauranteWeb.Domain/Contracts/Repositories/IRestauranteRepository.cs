using RestauranteWeb.Domain.Entities.Restaurantes;
using System;

namespace RestauranteWeb.Domain.Contracts.Repositories
{
    public interface IRestauranteRepository : IBaseRepository<Restaurante, Guid>
    {
    }
}
