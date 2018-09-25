using prmToolkit.NotificationPattern;
using RestauranteWeb.CrossCutting.Negocio;
using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Contracts.Services;
using System.Collections.Generic;

namespace RestauranteWeb.Domain.Services
{
    public abstract class CadastroBaseService<TEntity, TKey> : EntityValidationService<TEntity>, ICadastroBaseService<TEntity, TKey> where TEntity : Notifiable
    {
        protected IBaseRepository<TEntity, TKey> Repository { get; set; }

        protected CadastroBaseService(IBaseRepository<TEntity, TKey> repository)
        {
            Repository = repository;
        }

        public async System.Threading.Tasks.Task<ResultadoNegocio<TEntity>> Add(TEntity obj)
        {
            var resultado = new ResultadoNegocio<TEntity>()
                .TrateResultado(obj);

            if (resultado.Sucesso)
            {
                await Repository.Add(obj);
            }

            return resultado;
        }

        public async System.Threading.Tasks.Task<ResultadoNegocio<TEntity>> AddOrUpdate(TEntity obj)
        {
            var resultado = new ResultadoNegocio<TEntity>()
                .TrateResultado(obj);

            if (resultado.Sucesso)
            {
                await Repository.AddOrUpdate(obj);
            }

            return resultado;
        }

        public async System.Threading.Tasks.Task<IEnumerable<TEntity>> GetAll()
        {
            return await Repository.GetAll();
        }

        public async System.Threading.Tasks.Task<TEntity> GetById(TKey id)
        {
            return await Repository.GetById(id);
        }

        public async System.Threading.Tasks.Task<ResultadoNegocio<TEntity>> Remove(TEntity obj)
        {
            var result = await Repository.Remove(obj);
            return new ResultadoNegocio<TEntity>()
                        .TrateResultado(result);
        }

        public async System.Threading.Tasks.Task<ResultadoNegocio<TEntity>> Update(TEntity obj)
        {
            var resultado = new ResultadoNegocio<TEntity>()
                .TrateResultado(obj);

            if (resultado.Sucesso)
            {
                await Repository.Update(obj);
            }

            return resultado;
        }
    }
}
