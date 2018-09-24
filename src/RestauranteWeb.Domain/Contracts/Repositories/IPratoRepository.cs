using RestauranteWeb.Domain.Entities.Pratos;
using System;

namespace RestauranteWeb.Domain.Contracts.Repositories
{
    public interface IPratoRepository : IBaseRepository<Prato, Guid>
    {
    }
}
