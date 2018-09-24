using prmToolkit.NotificationPattern;

namespace RestauranteWeb.Domain.Entities
{
    public abstract class EntidadeBase<TTipoChave> : Notifiable
    {
        public TTipoChave IdEntidade { get; set; }
    }
}
