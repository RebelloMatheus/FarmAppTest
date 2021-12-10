using FarmApp.Dominio.Contratos;
using MediatR;

namespace FarmApp.Dominio.Mediator.Mediators.Requests.Consultar
{
    public class VerificarCertificadoRequest : IRequest<CertificadoContrato>
    {
        public string Token { get; private set; }

        public VerificarCertificadoRequest(string token)
        {
            Token = token;
        }
    }
}