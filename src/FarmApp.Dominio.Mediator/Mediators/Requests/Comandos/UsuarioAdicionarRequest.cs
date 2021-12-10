using FarmApp.Dominio.Contratos;
using MediatR;

namespace FarmApp.Dominio.Mediator.Mediators.Requests.Comandos
{
    public class UsuarioAdicionarRequest : IRequest<UsuarioCadastradoContrato>
    {
        public UsuarioContrato Contrato { get; private set; }

        public UsuarioAdicionarRequest(UsuarioContrato contrato)
        {
            Contrato = contrato;
        }
    }
}