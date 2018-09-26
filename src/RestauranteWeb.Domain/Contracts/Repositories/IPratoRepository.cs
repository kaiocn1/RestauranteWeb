using RestauranteWeb.Domain.Entities.Pratos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteWeb.Domain.Contracts.Repositories
{
    public interface IPratoRepository : IBaseRepository<Prato, Guid>
    {
        Task<IEnumerable<Prato>> GetAllByRestaurantId(Guid restauranteId);
    }
}
