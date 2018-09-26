using prmToolkit.NotificationPattern;
using RestauranteWeb.Domain.Entities.Restaurantes;
using RestauranteWeb.Domain.SharedKernel;
using System;
using System.Collections.Generic;

namespace RestauranteWeb.Domain.Entities.Pratos
{
    public class Prato : EntidadeBaseCadastro<Guid>, IEntityValidation<Prato>
    {
        public string Descricao { get; set; }
        public Restaurante Restaurante { get; set; }
        public decimal Preco { get; set; }
        public Guid RestauranteId { get; set; }
        public IReadOnlyCollection<Notification> Validate()
        {
            new AddNotifications<Prato>(this)
                .IfNullOrEmpty(Descricao,
                               "Descrição",
                               "Descrição deve ser informada.");

            new AddNotifications<Prato>(this)
                .IfNull(Restaurante,
                        "Restaurante",
                        "Restaurante deve ser informado.");

            return Notifications;
        }
    }
}
