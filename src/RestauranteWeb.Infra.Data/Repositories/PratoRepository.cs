using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Domain.Contracts.Repositories;
using RestauranteWeb.Domain.Entities.Pratos;
using RestauranteWeb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWeb.Infra.Data.Repositories
{
    public class PratoRepository : BaseCadastroRepository<Prato, Guid>, IPratoRepository
    {
        public async Task<IEnumerable<Prato>> GetAllByRestaurantId(Guid restauranteId)
        {
            using (var Db = new RestauranteWebContext())
            {
                return await Db.Set<Prato>()
                               .Where(x => x.StatusRegistro == 0 && x.RestauranteId == restauranteId)
                               .ToListAsync();
            }
        }
    }
}
