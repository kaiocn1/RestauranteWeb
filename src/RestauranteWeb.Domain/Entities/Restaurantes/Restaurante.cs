using prmToolkit.NotificationPattern;
using RestauranteWeb.Domain.Entities.Pratos;
using RestauranteWeb.Domain.SharedKernel;
using System;
using System.Collections.Generic;

namespace RestauranteWeb.Domain.Entities.Restaurantes
{
    public class Restaurante : EntidadeBaseCadastro<Guid>, IEntityValidation<Restaurante>
    {
        public string Descricao { get; set; }

        public IEnumerable<Prato> Pratos { get; set; }

        public IReadOnlyCollection<Notification> Validate()
        {
            new AddNotifications<Restaurante>(this)
                .IfNullOrEmpty(Descricao,
                               "Descrição",
                               "Descrição deve ser informada");

            return Notifications;
        }
    }
}
