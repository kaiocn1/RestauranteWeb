using RestauranteWeb.CrossCutting.Negocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteWeb.Domain.Contracts.Services
{
    public interface ICadastroBaseService<TEntity, in TKey>
    {
        Task<ResultadoNegocio<TEntity>> Add(TEntity obj);
        Task<ResultadoNegocio<TEntity>> GetById(TKey id);
        Task<ResultadoNegocio<IEnumerable<TEntity>>> GetAll();
        Task<ResultadoNegocio<TEntity>> Update(TEntity obj);
        Task<ResultadoNegocio<TEntity>> AddOrUpdate(TEntity obj);
        Task<ResultadoNegocio<TEntity>> Remove(TEntity obj);
    }
}
