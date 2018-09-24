using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Entities.Pratos;
using System;

namespace RestauranteWeb.Infra.Data.Repositories
{
    public class PratoRepository : BaseCadastroRepository<Prato, Guid>, IPratoRepository
    {
    }
}
