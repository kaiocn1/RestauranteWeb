using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteWeb.Domain.Entities.Restaurantes;
using System;

namespace RestauranteWeb.Infra.Data.Configurations
{
    public class RestauranteConfiguration : EntidadeBaseCadastroConfiguration<Restaurante, Guid>
    {
        public RestauranteConfiguration() : base("Restaurantes", "RestauranteId")
        {
        }

        public override void ConfigureCampos(EntityTypeBuilder<Restaurante> builder)
        {
            builder.Property(x => x.Descricao)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasMany(p => p.Pratos)
                   .WithOne(c => c.Restaurante);
        }
    }
}
