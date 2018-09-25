using RestauranteWeb.Application.ViewModels.Pratos;
using System;

namespace RestauranteWeb.Application.Contracts
{
    public interface IPratoAppService : IAppCadastroServiceBase<PratoViewModel, Guid>
    {
    }
}
