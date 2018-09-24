using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace RestauranteWeb.Domain.SharedKernel
{
    public interface IEntityValidation<T> where T : Notifiable
    {
        IReadOnlyCollection<Notification> Validate();
    }
}
