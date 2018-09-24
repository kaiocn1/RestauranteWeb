using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Entities;
using RestauranteWeb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWeb.Infra.Data.Repositories
{
    public abstract class BaseCadastroRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : EntidadeBaseCadastro<TKey>
    {
        private const byte INDICADOR_EXCLUSAO = 1;

        public virtual async Task Add(TEntity obj)
        {
            using (var Db = new RestauranteWebContext())
            {
                Db.Set<TEntity>().Add(obj);
                await Db.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetById(TKey id)
        {
            using (var Db = new RestauranteWebContext())
            {
                return await Db.Set<TEntity>()
                               .FindAsync(id);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (var Db = new RestauranteWebContext())
            {
                return await Db.Set<TEntity>()
                               .Where(x => x.StatusRegistro == 0)
                               .ToListAsync();
            }
        }

        public virtual async Task<TEntity> Update(TEntity obj)
        {
            using (var Db = new RestauranteWebContext())
            {
                Db.Entry(obj).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return obj;
            }
        }

        public virtual Task<TEntity> AddOrUpdate(TEntity obj)
        {
            throw new NotImplementedException("Método não implementado para Suite");
        }

        public virtual async Task<TEntity> Remove(TEntity obj)
        {
            using (var Db = new RestauranteWebContext())
            {
                var objetoPersistido = await Db.Set<TEntity>().FindAsync(obj.IdEntidade);
                objetoPersistido.StatusRegistro = INDICADOR_EXCLUSAO;
                objetoPersistido.DataHoraInativacao = DateTime.Now;
                objetoPersistido.UsuarioInativacao = new Guid(); // TODO: Ajustar para pegar o usuário do contexto
                Db.Entry(objetoPersistido).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return obj;
            }
        }
    }
}
