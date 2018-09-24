using Microsoft.Extensions.DependencyInjection;
using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Contracts.Services;
using RestauranteWeb.Domain.Services;
using RestauranteWeb.Infra.Data.Repositories;

namespace RestauranteWeb.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Services
            services.AddScoped<IPratoService, PratoService>();
            services.AddScoped<IRestauranteService, RestauranteService>();

            // Repositories
            services.AddScoped<IPratoRepository, PratoRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
        }
    }
}
