using Moq;
using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Services;
using RestauranteWeb.Domain.Test.DomainBuilder;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RestauranteWeb.Domain.Test
{
    public class RestauranteService_Test
    {
        [Fact]
        public void Add_Test()
        {
            var mockRestauranteRepository = new Mock<IRestauranteRepository>();
            var mockPratoRepository = new Mock<IPratoRepository>();

            var restaurante = new RestauranteBuilder()
                .CenarioBasico()
                .Crie();

            mockRestauranteRepository.Setup(m => m.Add(restaurante)).Returns(Task.FromResult(restaurante));
            var servico = new RestauranteService(mockRestauranteRepository.Object, mockPratoRepository.Object);

            var restultado = Task.Run(() => servico.Add(restaurante)).Result;

            Assert.NotNull(restultado);
            Assert.True(restultado.Sucesso);
            Assert.Empty(restultado.Mensagens);
        }

        [Fact]
        public void Add_DescricaoVazia_Test()
        {
            var mockRestauranteRepository = new Mock<IRestauranteRepository>();
            var mockPratoRepository = new Mock<IPratoRepository>();

            var restaurante = new RestauranteBuilder()
                .CenarioSemDescricao()
                .Crie();

            mockRestauranteRepository.Setup(m => m.Add(restaurante)).Returns(Task.FromResult(restaurante));
            var servico = new RestauranteService(mockRestauranteRepository.Object, mockPratoRepository.Object);

            var restultado = Task.Run(() => servico.Add(restaurante)).Result;

            Assert.NotNull(restultado);
            Assert.False(restultado.Sucesso);
            Assert.Single(restultado.Mensagens);
            Assert.True(restultado.Mensagens.ContainsKey("Descrição"));
            Assert.Equal("Descrição deve ser informada", restultado.Mensagens["Descrição"].First());
        }
    }
}
