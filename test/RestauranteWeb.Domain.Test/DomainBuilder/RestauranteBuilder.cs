using RestauranteWeb.Domain.Entities.Restaurantes;

namespace RestauranteWeb.Domain.Test.DomainBuilder
{
    public class RestauranteBuilder
    {
        private readonly Restaurante _interno;

        public RestauranteBuilder()
        {
            _interno = new Restaurante();
        }

        public RestauranteBuilder CenarioBasico()
        {
            _interno.Descricao = "Restaurante";
            return this;
        }

        public RestauranteBuilder CenarioSemDescricao()
        {
            _interno.Descricao = string.Empty;
            return this;
        }

        public Restaurante Crie()
        {
            return _interno;
        }
    }
}
