using RestauranteWeb.Domain.Entities.Pratos;
using System;

namespace RestauranteWeb.Domain.Test.DomainBuilder
{
    public class PratoBuilder
    {
        private readonly Prato _interno;

        public PratoBuilder()
        {
            _interno = new Prato();
        }

        public PratoBuilder CenarioBasico()
        {
            _interno.Descricao = "Prato";
            _interno.RestauranteId = Guid.NewGuid();
            return this;
        }

        public PratoBuilder CenarioSemDescricao()
        {
            _interno.Descricao = string.Empty;
            _interno.RestauranteId = Guid.NewGuid();
            return this;
        }

        public PratoBuilder CenarioSemRestaurante()
        {
            _interno.Descricao = "Prato";
            _interno.RestauranteId = Guid.Empty;
            return this;
        }

        public Prato Crie()
        {
            return _interno;
        }
    }
}
