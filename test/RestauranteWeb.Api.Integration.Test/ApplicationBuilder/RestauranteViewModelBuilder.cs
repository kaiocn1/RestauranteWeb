using RestauranteWeb.Application.ViewModels.Restaurantes;

namespace RestauranteWeb.Api.Integration.Test.ApplicationBuilder
{
    public class RestauranteViewModelBuilder
    {
        private readonly RestauranteViewModel _interno;

        public RestauranteViewModelBuilder()
        {
            _interno = new RestauranteViewModel();
        }

        public RestauranteViewModelBuilder CenarioBasico()
        {
            _interno.Descricao = "Restaurante";
            return this;
        }

        public RestauranteViewModel Crie()
        {
            return _interno;
        }
    }
}
