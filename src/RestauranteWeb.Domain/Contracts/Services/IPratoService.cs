using RestauranteWeb.Domain.Entities.Pratos;
using System;

namespace RestauranteWeb.Domain.Contracts.Services
{
    public interface IPratoService : ICadastroBaseService<Prato, Guid>
    {
    }
}
