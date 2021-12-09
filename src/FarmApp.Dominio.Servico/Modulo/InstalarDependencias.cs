using FarmApp.Infra.BancoDeDados.Contexto;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarServicoFarmApp(this IServiceCollection servicos, IConfiguration configuracao)
        {
            // Services.
            //servicos.TryAddScoped<IT, T>();

            // Contracters
            //servicos.TryAddScoped<IT, T>();

            // Service dependencies.
            servicos.AdicionarBancoDeDados<FarmAppContexto>(configuracao);

            // Configurations
            AdicionarConfiguracao(servicos, configuracao);
        }

        private static void AdicionarConfiguracao(IServiceCollection servicos, IConfiguration configuracao)
        { }
    }
}