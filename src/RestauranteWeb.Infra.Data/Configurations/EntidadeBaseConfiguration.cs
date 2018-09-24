using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteWeb.Domain.Entities;

namespace RestauranteWeb.Infra.Data.Configurations
{
    public abstract class EntidadeBaseConfiguration<T, TKey> : IEntityTypeConfiguration<T>
        where T : EntidadeBase<TKey>
    {
        protected string NomeTabela { get; set; }
        protected string NomeCampoChave { get; set; }

        protected EntidadeBaseConfiguration(string nomeTabela) : this(nomeTabela, string.Empty)
        {
        }

        protected EntidadeBaseConfiguration(string nomeTabela, string nomeCampoChave)
        {
            NomeTabela = nomeTabela;
            NomeCampoChave = nomeCampoChave;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (string.IsNullOrEmpty(NomeCampoChave))
                NomeCampoChave = "ID" + typeof(T).Name.ToUpper();

            builder.ToTable(NomeTabela);

            builder.HasKey(x => x.IdEntidade)
                   .HasName(NomeCampoChave);

            builder.Property(x => x.IdEntidade)
                   .ValueGeneratedOnAdd();
        }
    }
}
