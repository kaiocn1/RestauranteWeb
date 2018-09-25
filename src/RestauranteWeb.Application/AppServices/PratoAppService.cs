using RestauranteWeb.Application.Contracts;
using RestauranteWeb.Application.ViewModels.Pratos;
using RestauranteWeb.Domain.Contracts.Services;
using RestauranteWeb.Domain.Entities.Pratos;
using System;

namespace RestauranteWeb.Application.AppServices
{
    public class PratoAppService : AppCadastroServiceBase<Prato, PratoViewModel, Guid>, IPratoAppService
    {
        public PratoAppService(IPratoService serviceBase) : base(serviceBase)
        {
        }
    }
}
