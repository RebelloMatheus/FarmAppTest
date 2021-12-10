using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Interfaces.Servico;
using FarmApp.Dominio.Mediator.Mediators.Requests.Comandos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FarmApp.Dominio.Mediator.Mediators.Handlers.Comandos
{
    internal class UsuarioAdicionarHandler :
        IRequestHandler<UsuarioAdicionarRequest, UsuarioCadastradoContrato>
    {
        private readonly IUsuarioServico Servico;

        public UsuarioAdicionarHandler(IUsuarioServico servico)
        {
            Servico = servico;
        }

        public Task<UsuarioCadastradoContrato> Handle(UsuarioAdicionarRequest request, CancellationToken cancellationToken)
        {
            return Servico.AdicionarAsync(request.Contrato, cancellationToken);
        }
    }
}