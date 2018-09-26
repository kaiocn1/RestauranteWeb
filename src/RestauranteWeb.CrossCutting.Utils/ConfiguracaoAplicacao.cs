using Microsoft.Extensions.Configuration;
using System.IO;

namespace RestauranteWeb.CrossCutting.Utils
{
    public static class ConfiguracaoAplicacao
    {
        public static string ObterConfiguracao(string nome)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return config[nome];
        }

        public static string ObterStringConexao(string nome)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return config.GetConnectionString(nome);
        }
    }
}
