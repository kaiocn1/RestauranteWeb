using Microsoft.EntityFrameworkCore;
using RestauranteWeb.CrossCutting.Utils;
using RestauranteWeb.Infra.Data.Configurations;
using System;
using System.Linq;

namespace RestauranteWeb.Infra.Data.Context
{
    public class RestauranteWebContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RestauranteConfiguration());
            modelBuilder.ApplyConfiguration(new PratoConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }

        private string GetTableName(Type type)
        {
            return type.Name.ToUpperInvariant();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ConfiguracaoConexao.Crie().ExecucaoTesteUnitario)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "Add_writes_to_database");
                return;
            }

            optionsBuilder.UseSqlServer(ConfiguracaoConexao.Crie().StringConexao);
        }
    }
}
