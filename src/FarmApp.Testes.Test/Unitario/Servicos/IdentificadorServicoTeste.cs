using FarmApp.Dominio.Modelos;
using FarmApp.Infra.BancoDeDados.Repositorio.Base;
using FarmApp.Testes.Test.Fixtures;
using FarmApp.Testes.Test.Integracao;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Testes.Test.Unitario.Servicos
{
    internal class IdentificadorServicoTeste : ModeloTesteBase
    {
        private IRepositorioBase repositorioBase;

        protected override void SetUpFarmApp()
        {
            repositorioBase = ObterServico<IRepositorioBase>();
        }

        [Test]
        public async Task Usuario_Cadastrar_DeveEstarValido()
        {
            var usuario = new UsuarioFixture().GerarValido();
            await repositorioBase.AdicionarAsync(usuario).ConfigureAwait(false);

            var retorno = await repositorioBase.ObterTodosAsync<Usuario>().ConfigureAwait(false);

            retorno.Should().NotBeNull();
            retorno.Count().Should().Be(1);
        }
    }
}