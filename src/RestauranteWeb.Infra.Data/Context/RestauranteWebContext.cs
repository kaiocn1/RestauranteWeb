using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using RestauranteWeb.CrossCutting.Utils;
using RestauranteWeb.Infra.Data.Configurations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteWeb.Infra.Data.Context
{
    public class RestauranteWebContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RestauranteConfiguration());
            modelBuilder.ApplyConfiguration(new PratoConfiguration());
            modelBuilder.Ignore<Notification>();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataHoraCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataHoraCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataHoraCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataHoraCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataHoraCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataHoraCadastro").IsModified = false;
                }
            }


            return base.SaveChangesAsync(cancellationToken);
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
