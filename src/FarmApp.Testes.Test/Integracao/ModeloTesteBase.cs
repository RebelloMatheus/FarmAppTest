using FarmApp.Infra.BancoDeDados.Contexto;
using FarmApp.Testes.Test.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace FarmApp.Testes.Test.Integracao
{
    public abstract class ModeloTesteBase : TesteBase
    {
        protected override void AdicionarServico(IServiceCollection servicos, IConfiguration configuracao)
        {
            AdicionarBancoDeDadosTeste<FarmAppContexto>();
            servicos.AdicionarServicoFarmApp(configuracao);
            servicos.AddLogging();

            AdicionarServicoMocado(servicos, configuracao);
        }

        protected override void SetUp()
        {
            SetUpFarmApp();
        }

        protected abstract void SetUpFarmApp();

        protected TServico ObterServicoMocado<TServico>()
            where TServico : class
        {
            TServico servico = Substitute.For<TServico>();
            return servico;
        }

        protected virtual void AdicionarServicoMocado(IServiceCollection servicos, IConfiguration configuracao)
        { }
    }
}