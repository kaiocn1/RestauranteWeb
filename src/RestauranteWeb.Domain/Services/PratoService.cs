using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Contracts.Services;
using RestauranteWeb.Domain.Entities.Pratos;
using System;

namespace RestauranteWeb.Domain.Services
{
    public class PratoService : CadastroBaseService<Prato, Guid>, IPratoService
    {
        public PratoService(IPratoRepository repository) : base(repository)
        {
        }
    }
}
