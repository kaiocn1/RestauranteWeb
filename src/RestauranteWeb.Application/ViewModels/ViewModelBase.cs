namespace RestauranteWeb.Application.ViewModels
{
    public abstract class ViewModelBase<TKey>
    {
        public TKey IdEntidade { get; set; }
    }
}
