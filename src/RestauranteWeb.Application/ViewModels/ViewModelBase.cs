using System.Collections.Generic;

namespace RestauranteWeb.Application.ViewModels
{
    public abstract class ViewModelBase<TKey>
    {
        public TKey IdEntidade { get; set; }

        public Dictionary<string, List<string>> Mensagens { get; set; }
    }
}
