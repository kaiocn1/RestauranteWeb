using Moq;
using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Entities.Restaurantes;
using RestauranteWeb.Domain.Services;
using Xunit;

namespace RestauranteWeb.Api.Test
{
    public class RestauranteService_Test
    {

        [Fact]
        public void Add_Test()
        {
            var mockRestauranteRepository = new Mock<IRestauranteRepository>();
            var mockPratoRepository = new Mock<IPratoRepository>();

            var restaurante = new Restaurante();

            restaurante.Descricao = "Descricao";

            mockRestauranteRepository.Setup(m => m.Add(It.IsAny<Restaurante>())).Returns(new Restaurante { IdEntidade = acaoId });


            var servico = new RestauranteService(mockRestauranteRepository.Object, mockPratoRepository.Object);
        }
    }
}
