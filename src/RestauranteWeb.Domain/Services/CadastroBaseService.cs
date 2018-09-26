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
            var resultadoValidacao = Validate(obj);

            if (!resultadoValidacao.Sucesso)
            {
                return new ResultadoNegocio<TEntity>()
                    .AdicioneResultadoValidacao(obj, resultadoValidacao); ;
            }

            await Repository.Add(obj);

            return new ResultadoNegocio<TEntity>()
                .TrateResultado(obj); ;
        }

        public async System.Threading.Tasks.Task<ResultadoNegocio<TEntity>> AddOrUpdate(TEntity obj)
        {
            var resultadoValidacao = Validate(obj);

            if (!resultadoValidacao.Sucesso)
            {
                return new ResultadoNegocio<TEntity>()
                    .AdicioneResultadoValidacao(obj, resultadoValidacao); ;
            }

            await Repository.AddOrUpdate(obj);
            return new ResultadoNegocio<TEntity>()
                .TrateResultado(obj); ;
        }

        public async System.Threading.Tasks.Task<IEnumerable<TEntity>> GetAll()
        {
            return await Repository.GetAll();
        }

        public async System.Threading.Tasks.Task<TEntity> GetById(TKey id)
        {
            return await Repository.GetById(id);
        }

        public virtual async System.Threading.Tasks.Task<ResultadoNegocio<TEntity>> Remove(TKey obj)
        {
            var objeto = await GetById(obj);
            var result = await Repository.Remove(objeto);
            return new ResultadoNegocio<TEntity>()
                        .TrateResultado(result);
        }

        public async System.Threading.Tasks.Task<ResultadoNegocio<TEntity>> Update(TEntity obj)
        {
            var resultadoValidacao = Validate(obj);

            if (!resultadoValidacao.Sucesso)
            {
                return new ResultadoNegocio<TEntity>()
                    .AdicioneResultadoValidacao(obj, resultadoValidacao); ;
            }

            await Repository.Update(obj);

            return new ResultadoNegocio<TEntity>()
                .TrateResultado(obj); ;
        }
    }
}
