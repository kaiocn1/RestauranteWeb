using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteWeb.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity, in TKey>
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(TKey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Update(TEntity obj);
        Task<TEntity> AddOrUpdate(TEntity obj);
        Task<TEntity> Remove(TEntity obj);
    }
}
