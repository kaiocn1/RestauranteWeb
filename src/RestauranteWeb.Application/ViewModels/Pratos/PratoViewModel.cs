using RestauranteWeb.Application.ViewModels.Restaurantes;
using System;

namespace RestauranteWeb.Application.ViewModels.Pratos
{
    public class PratoViewModel : ViewModelBase<Guid>
    {
        public string Descricao { get; set; }

        public RestauranteViewModel Restaurante { get; set; }
    }
}
