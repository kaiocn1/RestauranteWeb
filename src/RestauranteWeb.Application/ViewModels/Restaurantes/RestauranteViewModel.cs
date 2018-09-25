using System;

namespace RestauranteWeb.Application.ViewModels.Restaurantes
{
    public class RestauranteViewModel : ViewModelBase<Guid>
    {
        public string Descricao { get; set; }
    }
}
