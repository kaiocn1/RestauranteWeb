using AutoMapper;
using RestauranteWeb.Api.Integration.Test.ApplicationBuilder;
using RestauranteWeb.Application.ViewModels.Pratos;
using RestauranteWeb.Application.ViewModels.Restaurantes;
using RestauranteWeb.CrossCutting.Utils;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RestauranteWeb.Api.Integration.Test
{
    public class PratoAppService_Test : BaseIntegrationTest, IDisposable
    {
        [Fact]
        public async Task AddPrato_Test()
        {
            var restaurante = new RestauranteViewModelBuilder().CenarioBasico().Crie();
            var response = await Client.PostAsync("/api/Restaurante/Post", restaurante.ToJon());
            response.EnsureSuccessStatusCode();

            var restauranteViewModel = await JsonToObject<RestauranteViewModel>.Convert(response);

            var restauranteBanco = await Client.GetAsync("/api/Restaurante/" + restauranteViewModel.IdEntidade);
            restauranteBanco.EnsureSuccessStatusCode();

            var restauranteResposta = await JsonToObject<RestauranteViewModel>.Convert(restauranteBanco);

            Assert.NotNull(restauranteResposta);

            var prato = new PratoViewModelBuilder().CenarioBasico().Crie();

            prato.RestauranteId = restauranteResposta.IdEntidade;

            var pratoResponse = await Client.PostAsync("/api/Prato/Post", prato.ToJon());
            response.EnsureSuccessStatusCode();

            var pratoViewModel = await JsonToObject<PratoViewModel>.Convert(pratoResponse);

            var pratoBanco = await Client.GetAsync("/api/Prato/" + pratoViewModel.IdEntidade);
            pratoBanco.EnsureSuccessStatusCode();

            var pratoResposta = await JsonToObject<PratoViewModel>.Convert(pratoBanco);

            Assert.NotNull(pratoResposta);
        }

        public void Dispose()
        {
            Mapper.Reset();
        }
    }
}
