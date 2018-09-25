using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteWeb.Application.Contracts
{
    public interface IAppCadastroServiceBase<TViewModel, in TKey>
    {
        Task<TViewModel> Add(TViewModel obj);
        Task<TViewModel> GetById(TKey id);
        Task<IEnumerable<TViewModel>> GetAll();
        Task<TViewModel> Update(TViewModel obj);
        Task<TViewModel> AddOrUpdate(TViewModel obj);
        Task<TViewModel> Remove(TViewModel obj);
    }
}
