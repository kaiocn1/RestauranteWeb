using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteWeb.Domain.Entities;

namespace RestauranteWeb.Infra.Data.Configurations
{
    public abstract class EntidadeBaseCadastroConfiguration<T, TKey> : EntidadeBaseConfiguration<T, TKey>
         where T : EntidadeBaseCadastro<TKey>
    {
        protected EntidadeBaseCadastroConfiguration(string nomeTabela) : base(nomeTabela)
        {
        }

        protected EntidadeBaseCadastroConfiguration(string nomeTabela, string nomeCampoChave) : base(nomeTabela, nomeCampoChave)
        {
        }

        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            this.ConfigureCampos(builder);

            builder.Property(x => x.StatusRegistro)
                   .IsRequired();

            builder.Property(x => x.DataHoraCadastro)
                   .IsRequired();

            builder.Property(x => x.UsuarioCriador)
                   .IsRequired();

            builder.Property(x => x.DataHoraInativacao);

            builder.Property(x => x.UsuarioInativacao);
        }

        public abstract void ConfigureCampos(EntityTypeBuilder<T> builder);
    }
}
