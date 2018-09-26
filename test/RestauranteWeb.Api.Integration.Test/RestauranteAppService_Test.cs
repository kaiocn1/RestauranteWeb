using AutoMapper;
using RestauranteWeb.Api.Integration.Test.ApplicationBuilder;
using RestauranteWeb.Application.ViewModels.Restaurantes;
using RestauranteWeb.CrossCutting.Utils;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RestauranteWeb.Api.Integration.Test
{
    public class RestauranteAppService_Test : BaseIntegrationTest, IDisposable
    {
        [Fact]
        public async Task AddRestaurante_Test()
        {
            var restaurante = new RestauranteViewModelBuilder().CenarioBasico().Crie();
            var response = await Client.PostAsync("/api/Restaurante/Post", restaurante.ToJon());
            response.EnsureSuccessStatusCode();

            var clienteViewModel = await JsonToObject<RestauranteViewModel>.Convert(response);

            var clienteBanco = await Client.GetAsync("/api/Restaurante/" + clienteViewModel.IdEntidade);
            clienteBanco.EnsureSuccessStatusCode();

            var clienteResposta = await JsonToObject<RestauranteViewModel>.Convert(clienteBanco);

            Assert.NotNull(clienteResposta);
        }

        public void Dispose()
        {
            Mapper.Reset();
        }
    }
}
