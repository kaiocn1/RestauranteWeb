using Microsoft.Extensions.DependencyInjection;
using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Infra.Data.Repositories;

namespace RestauranteWeb.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Repository
            services.AddScoped<IPratoRepository, PratoRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
        }
    }
}
