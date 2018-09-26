using RestauranteWeb.CrossCutting.Negocio;
using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Contracts.Services;
using RestauranteWeb.Domain.Entities.Restaurantes;
using System;

namespace RestauranteWeb.Domain.Services
{
    public class RestauranteService : CadastroBaseService<Restaurante, Guid>, IRestauranteService
    {
        private readonly IPratoRepository _pratoRepository;

        public RestauranteService(IRestauranteRepository repository, IPratoRepository pratoRepository) : base(repository)
        {
            _pratoRepository = pratoRepository;
        }

        public override async System.Threading.Tasks.Task<ResultadoNegocio<Restaurante>> Remove(Guid id)
        {
            var restaurante = await GetById(id);

            if (restaurante == null)
            {
                return new ResultadoNegocio<Restaurante>();
            }

            var pratos = await _pratoRepository.GetAllByRestaurantId(id);

            foreach (var prato in pratos)
            {
                await _pratoRepository.Remove(prato);
            }

            var result = await Repository.Remove(restaurante);
            return new ResultadoNegocio<Restaurante>()
                .TrateResultado(result);
        }
    }
}
