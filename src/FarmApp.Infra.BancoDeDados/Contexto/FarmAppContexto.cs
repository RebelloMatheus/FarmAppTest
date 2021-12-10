using FarmApp.Infra.BancoDeDados.Contexto.Base;
using Microsoft.EntityFrameworkCore;

namespace FarmApp.Infra.BancoDeDados.Contexto
{
    public class FarmAppContexto : ContextoBase
    {
        public override string ContextoNome => nameof(FarmAppContexto);

        public FarmAppContexto(DbContextOptions options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();

                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FarmAppContexto).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}