using FarmApp.Infra.BancoDeDados.Contexto.Base;
using FarmApp.Infra.BancoDeDados.Repositorio.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public const string DatabaseConnectionString = "DefaultConnection";

        public static void AdicionarBancoDeDados<TContextoBase, TChavePrimaria>(this IServiceCollection servicos, IConfiguration configuracao)
            where TContextoBase : ContextoBase
        {
            servicos.AddDbContext<TContextoBase>(opt => opt.UseSqlServer(configuracao.GetConnectionString(DatabaseConnectionString)));
            servicos.AddScoped<IRepositorioBase<TChavePrimaria>, RepositorioBase<TContextoBase, TChavePrimaria>>();
        }

        public static void AdicionarBancoDeDados<TContextoTipo>(this IServiceCollection servicos, IConfiguration configuracao)
            where TContextoTipo : ContextoBase
        {
            servicos.AddDbContext<TContextoTipo>(opt => opt.UseSqlServer(configuracao.GetConnectionString(DatabaseConnectionString)));
            servicos.AddScoped<IRepositorioBase, RepositorioBase<TContextoTipo>>();
        }
    }
}