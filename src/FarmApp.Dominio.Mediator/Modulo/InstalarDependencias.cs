using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarRequisicoes(this IServiceCollection servicos, IConfiguration configuracao)
        {
            //servicos.AddMediatR(typeof(T).Assembly);
            servicos.AdicionarServicoFarmApp(configuracao);
        }
    }
}