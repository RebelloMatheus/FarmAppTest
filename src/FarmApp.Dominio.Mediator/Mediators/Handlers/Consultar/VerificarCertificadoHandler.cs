using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Interfaces.Servico;
using FarmApp.Dominio.Mediator.Mediators.Requests.Consultar;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FarmApp.Dominio.Mediator.Mediators.Handlers.Consultar
{
    internal class VerificarCertificadoHandler :
        IRequestHandler<VerificarCertificadoRequest, CertificadoContrato>
    {
        private readonly ICertificadoServico Servico;

        public VerificarCertificadoHandler(ICertificadoServico servico)
        {
            Servico = servico;
        }

        public Task<CertificadoContrato> Handle(VerificarCertificadoRequest request, CancellationToken cancellationToken)
        {
            return Servico.VerificarAsync(request.Token, cancellationToken);
        }
    }
}