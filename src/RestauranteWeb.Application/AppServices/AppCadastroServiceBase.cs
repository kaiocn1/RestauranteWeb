using AutoMapper;
using RestauranteWeb.Application.Contracts;
using RestauranteWeb.Application.ViewModels;
using RestauranteWeb.CrossCutting.Negocio;
using RestauranteWeb.CrossCutting.Utils;
using RestauranteWeb.Domain.Contracts.Services;
using RestauranteWeb.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteWeb.Application.AppServices
{
    public abstract class AppCadastroServiceBase<TEntity, TViewModel, TKey> : IAppCadastroServiceBase<TViewModel, TKey>
        where TEntity : EntidadeBase<TKey>
        where TViewModel : ViewModelBase<TKey>
    {
        protected ICadastroBaseService<TEntity, TKey> ServiceBase;

        protected AppCadastroServiceBase(ICadastroBaseService<TEntity, TKey> serviceBase)
        {
            ServiceBase = serviceBase;
        }

        public async Task<TViewModel> Add(TViewModel obj)
        {
            if (obj.IdEntidade.HasValueByKey()) return await UpdateConceito(obj);
            return await AddConceito(obj);
        }

        private async Task<TViewModel> AddConceito(TViewModel obj)
        {
            var entity = Mapper.Map<TEntity>(obj);
            var result = await ServiceBase.Add(entity);
            return TrateRetorno(result);
        }

        public async Task<TViewModel> GetById(TKey id)
        {
            var result = await ServiceBase.GetById(id);
            return Mapper.Map<TViewModel>(result);

        }

        public virtual async Task<IEnumerable<TViewModel>> GetAll()
        {
            var result = await ServiceBase.GetAll();
            return Mapper.Map<IEnumerable<TViewModel>>(result);
        }

        public async Task<TViewModel> Update(TViewModel obj)
        {
            return await UpdateConceito(obj);
        }

        private async Task<TViewModel> UpdateConceito(TViewModel obj)
        {
            var entity = Mapper.Map<TEntity>(obj);
            var result = await ServiceBase.Update(entity);
            return TrateRetorno(result);
        }

        public async Task<TViewModel> AddOrUpdate(TViewModel obj)
        {
            var entity = Mapper.Map<TEntity>(obj);
            var result = await ServiceBase.AddOrUpdate(entity);
            return TrateRetorno(result);
        }

        public async Task<TViewModel> Remove(TKey obj)
        {
            var result = await ServiceBase.Remove(obj);
            return TrateRetorno(result);
        }

        private TViewModel TrateRetorno(ResultadoNegocio<TEntity> resultadoNegocio)
        {
            var retorno = Mapper.Map<TViewModel>(resultadoNegocio.Retorno);
            retorno.Mensagens = resultadoNegocio.Mensagens;
            return retorno;
        }
    }
}
