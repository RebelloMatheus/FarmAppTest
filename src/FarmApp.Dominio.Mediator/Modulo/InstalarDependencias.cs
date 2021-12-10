using FarmApp.Dominio.Mediator.Mediators.Handlers.Comandos;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarRequisicoes(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddMediatR(typeof(UsuarioAdicionarHandler).Assembly);
            servicos.AdicionarServicoFarmApp(configuracao);
        }
    }
}