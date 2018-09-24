using RestauranteWeb.Domain.Entities.Restaurantes;
using System;

namespace RestauranteWeb.Domain.Contracts.Services
{
    public interface IRestauranteService : ICadastroBaseService<Restaurante, Guid>
    {
    }
}
