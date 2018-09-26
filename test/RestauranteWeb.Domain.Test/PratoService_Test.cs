using Moq;
using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Services;
using RestauranteWeb.Domain.Test.DomainBuilder;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RestauranteWeb.Domain.Test
{
    public class PratoService_Test
    {

        [Fact]
        public void Add_Test()
        {
            var mockPratoRepository = new Mock<IPratoRepository>();

            var prato = new PratoBuilder()
                .CenarioBasico()
                .Crie();

            mockPratoRepository.Setup(m => m.Add(prato)).Returns(Task.FromResult(prato));

            var servico = new PratoService(mockPratoRepository.Object);

            var restultado = Task.Run(() => servico.Add(prato)).Result;

            Assert.NotNull(restultado);
            Assert.True(restultado.Sucesso);
            Assert.Empty(restultado.Mensagens);
        }

        [Fact]
        public void Add_DescricaoVazia_Test()
        {
            var mockPratoRepository = new Mock<IPratoRepository>();

            var prato = new PratoBuilder()
                .CenarioSemDescricao()
                .Crie();

            mockPratoRepository.Setup(m => m.Add(prato)).Returns(Task.FromResult(prato));
            var servico = new PratoService(mockPratoRepository.Object);

            var restultado = Task.Run(() => servico.Add(prato)).Result;

            Assert.NotNull(restultado);
            Assert.False(restultado.Sucesso);
            Assert.Single(restultado.Mensagens);
            Assert.True(restultado.Mensagens.ContainsKey("Descrição"));
            Assert.Equal("Descrição deve ser informada.", restultado.Mensagens["Descrição"].First());
        }

        [Fact]
        public void Add_RestauranteVazio_Test()
        {
            var mockPratoRepository = new Mock<IPratoRepository>();

            var prato = new PratoBuilder()
                .CenarioSemRestaurante()
                .Crie();

            mockPratoRepository.Setup(m => m.Add(prato)).Returns(Task.FromResult(prato));
            var servico = new PratoService(mockPratoRepository.Object);

            var restultado = Task.Run(() => servico.Add(prato)).Result;

            Assert.NotNull(restultado);
            Assert.False(restultado.Sucesso);
            Assert.Single(restultado.Mensagens);
            Assert.True(restultado.Mensagens.ContainsKey("Restaurante"));
            Assert.Equal("Restaurante deve ser informado.", restultado.Mensagens["Restaurante"].First());
        }
    }
}
