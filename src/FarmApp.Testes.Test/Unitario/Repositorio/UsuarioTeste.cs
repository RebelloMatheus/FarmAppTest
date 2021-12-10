using FarmApp.Dominio.Extensoes;
using FarmApp.Dominio.Interfaces.Servico;
using FarmApp.Testes.Test.Fixtures;
using FarmApp.Testes.Test.Integracao;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FarmApp.Testes.Test.Unitario.Repositorio
{
    internal class UsuarioTeste : ModeloTesteBase
    {
        private IUsuarioServico usuarioServico;

        protected override void SetUpFarmApp()
        {
            usuarioServico = ObterServico<IUsuarioServico>();
        }

        [Test]
        public async Task Usuario_Adicionar_DeveEstarValido()
        {
            //Arrange
            var usuarioContrato = new UsuarioContratoFixture().GerarValido();

            //Act
            var retorno = await usuarioServico.AdicionarAsync(usuarioContrato, CancellationToken.None).ConfigureAwait(false);

            //Assert
            retorno.Usuario.Telefone.Should().Be(usuarioContrato.Telefone);
        }

        [Test]
        public async Task Usuario_Adicionar_DeveLacarExecaoJaCadastrado()
        {
            //Arrange
            var usuarioContrato = new UsuarioContratoFixture().GerarValido();

            //Act
            await usuarioServico.AdicionarAsync(usuarioContrato, CancellationToken.None).ConfigureAwait(false);
            Func<Task> ret = async () => await usuarioServico.AdicionarAsync(usuarioContrato, CancellationToken.None).ConfigureAwait(false);

            //Assert
            ret.Should().Throw<FarmAppException>().WithMessage($"Usuário cadastrado com telefone [{usuarioContrato.Telefone}] ou e-mail [{usuarioContrato.Email}].");
        }
    }
}