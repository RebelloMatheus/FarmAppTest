using FarmApp.Dominio.Contratos;
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
    internal class CertificadoServico : ICertificadoServico
    {
        private readonly IRepositorioBase repositorioBase;
        private readonly ICertificaoConversor certificaoConversor;
        private readonly ILogger<CertificadoServico> logger;

        public CertificadoServico(
            IRepositorioBase repositorioBase,
            ICertificaoConversor certificaoConversor,
            ILogger<CertificadoServico> logger)
        {
            this.repositorioBase = repositorioBase;
            this.certificaoConversor = certificaoConversor;
            this.logger = logger;
        }

        public async Task<CertificadoContrato> VerificarAsync(string token, CancellationToken cancellationToken)
        {
            Expression<Func<Certificado, bool>> filtro = x => x.Token == token;
            var certificado = await repositorioBase.PrimeiroOuPadraoAsync<Certificado>(filtro);
            if (certificado == null)
            {
                await Task.Run(() => { Console.WriteLine($"Token {token} é inválido"); });
                return null;
            }

            certificado.SetValidado(true);
            await repositorioBase.AtualizarAsync(certificado);

            return certificaoConversor.ConverterEntidadeParaContrato(certificado);
        }

        public async Task InserirAsync(string telefone, CancellationToken cancellationToken)
        {
            var token = new Random().Next(0, 999999).ToString("D4");
            var certificado = await repositorioBase.PrimeiroOuPadraoAsync<Certificado>(x => x.Telefone == telefone);

            if (certificado == null)
            {
                certificado = new Certificado(telefone, token);
                await repositorioBase.AdicionarAsync(certificado);
            }
            else
            {
                certificado.SetToken(token);
                await repositorioBase.AtualizarAsync(certificado);
            }

            await Task.Run(() => { Console.WriteLine($"Token enviado: {token}"); }, cancellationToken);
        }
    }
}