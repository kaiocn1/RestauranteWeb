using prmToolkit.NotificationPattern;
using RestauranteWeb.CrossCutting.Negocio;
using RestauranteWeb.Domain.Contracts.Services;
using RestauranteWeb.Domain.SharedKernel;
using System;

namespace RestauranteWeb.Domain.Services
{
    public class EntityValidationService<TEntity> : IEntityValidationService<TEntity> where TEntity : Notifiable
    {
        public ResultadoNegocio<bool> Validate(TEntity entity)
        {
            if (entity is IEntityValidation<TEntity> entityServiceValidation) return entityServiceValidation.Validate().TrateValidacoes();
            throw new ArgumentException($"O tipo {entity.GetType()} não é um objeto validável");
        }
    }
}
