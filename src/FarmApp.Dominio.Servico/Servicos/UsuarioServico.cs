using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Extensoes;
using FarmApp.Dominio.Interfaces.Conversores;
using FarmApp.Dominio.Interfaces.Servico;
using FarmApp.Dominio.Modelos;
using FarmApp.Infra.BancoDeDados.Repositorio.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FarmApp.Dominio.Servico.Servicos
{
    internal class UsuarioServico : IUsuarioServico
    {
        private readonly ILogger<UsuarioServico> logger;
        private readonly IRepositorioBase repositorio;
        private readonly IUsuarioConversor usuarioConversor;
        private readonly ICertificadoServico certificadoServico;

        public UsuarioServico(
            ILogger<UsuarioServico> logger,
            IRepositorioBase repositorio,
            IUsuarioConversor usuarioConversor,
            ICertificadoServico certificadoServico)
        {
            this.logger = logger;
            this.repositorio = repositorio;
            this.usuarioConversor = usuarioConversor;
            this.certificadoServico = certificadoServico;
        }

        public async Task<UsuarioCadastradoContrato> AdicionarAsync(UsuarioContrato contrato, CancellationToken cancellationToken)
        {
            Expression<Func<Usuario, bool>> filtro = x =>
                  x.Telefone.Equals(contrato.Telefone)
               || x.Email.Equals(contrato.Email);

            var jaCadastrado = await repositorio.ContarAsync<Usuario>(filtro).ConfigureAwait(false);

            if (jaCadastrado > 0)
            {
                logger.LogInformation($"Usuário cadastrado com telefone [{contrato.Telefone}] ou e-mail [{contrato.Email}].");
                throw new FarmAppException($"Usuário cadastrado com telefone [{contrato.Telefone}] ou e-mail [{contrato.Email}].");
            }

            var entidade = usuarioConversor.ConverterContratoParaEntidade(contrato);

            await repositorio.AdicionarAsync(entidade);

            logger.LogInformation($"Usuário Id={entidade.Id} cadastrado com sucesso");

            return usuarioConversor.ConverterEntidadeParaUsuarioCadastradoContrato(entidade);
        }

        public async Task<UsuarioContrato> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var usuario = await repositorio.ObterPorIdAsync<Usuario>(id);

            return usuarioConversor.ConverterEntidadeParaContrato(usuario);
        }

        public async Task<UsuarioContrato> ObterPorTelefoneAsync(string telefone, CancellationToken cancellationToken)
        {
            var usuario = await repositorio.PrimeiroOuPadraoAsync<Usuario>(x => x.Telefone == telefone);
            if (usuario != null)
            {
                logger.LogInformation($"Usuário do telefone {usuario.Telefone} já existe, Id: {usuario.Id}");
                return usuarioConversor.ConverterEntidadeParaContrato(usuario);
            }

            logger.LogInformation($"Usuário do telefone {telefone} será notificado com um Token em seu celular");
            await certificadoServico.InserirAsync(telefone, cancellationToken);

            return null;
        }
    }
}