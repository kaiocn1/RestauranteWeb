using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteWeb.Domain.Entities.Pratos;
using System;

namespace RestauranteWeb.Infra.Data.Configurations
{
    public class PratoConfiguration : EntidadeBaseCadastroConfiguration<Prato, Guid>
    {
        public PratoConfiguration() : base("Pratos", "PratoId")
        {
        }

        public override void ConfigureCampos(EntityTypeBuilder<Prato> builder)
        {
            builder.Property(x => x.Descricao)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasOne(p => p.Restaurante)
                   .WithMany(c => c.Pratos)
                   .HasForeignKey(p => p.RestauranteId)
                   .IsRequired();
        }
    }
}
