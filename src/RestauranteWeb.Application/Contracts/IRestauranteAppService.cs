using RestauranteWeb.Application.ViewModels.Restaurantes;
using System;

namespace RestauranteWeb.Application.Contracts
{
    public interface IRestauranteAppService : IAppCadastroServiceBase<RestauranteViewModel, Guid>
    {
    }
}
