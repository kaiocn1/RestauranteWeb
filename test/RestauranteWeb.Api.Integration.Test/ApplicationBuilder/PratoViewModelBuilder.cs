using RestauranteWeb.Application.ViewModels.Pratos;

namespace RestauranteWeb.Api.Integration.Test.ApplicationBuilder
{
    public class PratoViewModelBuilder
    {
        private readonly PratoViewModel _interno;

        public PratoViewModelBuilder()
        {
            _interno = new PratoViewModel();
        }

        public PratoViewModelBuilder CenarioBasico()
        {
            _interno.Descricao = "Prato";
            _interno.Preco = 20;

            return this;
        }

        public PratoViewModel Crie()
        {
            return _interno;
        }
    }
}
