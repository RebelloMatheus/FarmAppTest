using FarmApp.Dominio.Interfaces.Conversores;
using FarmApp.Dominio.Interfaces.Servico;
using FarmApp.Dominio.Servico.Conversores;
using FarmApp.Dominio.Servico.Servicos;
using FarmApp.Infra.BancoDeDados.Contexto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarServicoFarmApp(this IServiceCollection servicos, IConfiguration configuracao)
        {
            // Services.
            servicos.TryAddScoped<IUsuarioServico, UsuarioServico>();
            servicos.TryAddScoped<ICertificadoServico, CertificadoServico>();

            // Contracters
            servicos.TryAddScoped<IUsuarioConversor, UsuarioConversor>();
            servicos.TryAddScoped<ICertificaoConversor, CertificaoConversor>();

            // Service dependencies.
            servicos.AdicionarBancoDeDados<FarmAppContexto>(configuracao);

            // Configurations
            AdicionarConfiguracao(servicos, configuracao);
        }

        private static void AdicionarConfiguracao(IServiceCollection servicos, IConfiguration configuracao)
        { }
    }
}