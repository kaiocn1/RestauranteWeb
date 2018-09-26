using RestauranteWeb.CrossCutting.Negocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteWeb.Domain.Contracts.Services
{
    public interface ICadastroBaseService<TEntity, in TKey>
    {
        Task<ResultadoNegocio<TEntity>> Add(TEntity obj);
        Task<TEntity> GetById(TKey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<ResultadoNegocio<TEntity>> Update(TEntity obj);
        Task<ResultadoNegocio<TEntity>> AddOrUpdate(TEntity obj);
        Task<ResultadoNegocio<TEntity>> Remove(TKey obj);
    }
}
