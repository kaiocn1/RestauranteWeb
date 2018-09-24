using RestauranteWeb.CrossCutting.Negocio;

namespace RestauranteWeb.Domain.Contracts.Services
{
    public interface IEntityValidationService<in TEntity>
    {
        ResultadoNegocio<bool> Validate(TEntity entity);
    }
}
