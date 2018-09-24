using prmToolkit.NotificationPattern;
using RestauranteWeb.CrossCutting.Negocio;
using System.Collections.Generic;

namespace RestauranteWeb.Domain.SharedKernel
{
    public static class EntityValidationUtil
    {
        public static ResultadoNegocio<bool> TrateValidacoes(this IReadOnlyCollection<Notification> validacoes)
        {
            var resultado = new ResultadoNegocio<bool>();
            foreach (var notification in validacoes)
            {
                resultado.AdicioneMensagem(notification.Property, notification.Message);
            }
            resultado.TrateResultado(resultado.Sucesso);
            return resultado;
        }
    }
}
