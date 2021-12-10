using Bogus;
using FarmApp.Dominio.Interfaces.Servico;
using FarmApp.Dominio.Modelos;
using FarmApp.Infra.BancoDeDados.Repositorio.Base;
using FarmApp.Testes.Test.Fixtures;
using FarmApp.Testes.Test.Integracao;
using FluentAssertions;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace FarmApp.Testes.Test.Unitario.Servicos
{
    internal class CertificaoTeste : ModeloTesteBase
    {
        private ICertificadoServico certificadoServico;
        private IRepositorioBase repositorioBase;

        protected override void SetUpFarmApp()
        {
            certificadoServico = ObterServico<ICertificadoServico>();
            repositorioBase = ObterServico<IRepositorioBase>();
        }

        [Test]
        public async Task Certificado_Inserir_DeveEstarValido()
        {
            //Arrange
            string telefone = new Faker().Person.Phone;

            //Act
            await certificadoServico.InserirAsync(telefone, CancellationToken.None).ConfigureAwait(false);
            var retorno = await repositorioBase.ObterTodosAsync<Certificado>().ConfigureAwait(false);

            //Assert
            retorno[0].Telefone.Should().Be(telefone);
            retorno[0].Validado.Should().BeFalse();
        }

        [Test]
        public async Task Certificado_Verificar_DeveEstarValido()
        {
            //Arrange
            var certificado = await DadoUmCertificado();

            //Act
            var retorno = await certificadoServico.VerificarAsync(certificado.Token, CancellationToken.None).ConfigureAwait(false);

            //Assert
            retorno.Token.Should().Be(certificado.Token);
            retorno.Telefone.Should().Be(certificado.Telefone);
            retorno.Validado.Should().BeTrue();
        }

        private async Task<Certificado> DadoUmCertificado()
        {
            var certificado = new CertificadoFixture().GerarInvalidado();

            await repositorioBase.AdicionarAsync(certificado).ConfigureAwait(false);

            return certificado;
        }
    }
}