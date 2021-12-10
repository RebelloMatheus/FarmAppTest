using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Interfaces.Servico;
using FarmApp.Dominio.Mediator.Mediators.Requests.Consultar;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FarmApp.Dominio.Mediator.Mediators.Handlers.Consultar
{
    internal class ObterUsuarioPorTelefoneHandler :
        IRequestHandler<ObterUsuarioPorTelefoneRequest, UsuarioContrato>
    {
        private readonly IUsuarioServico Servico;

        public ObterUsuarioPorTelefoneHandler(IUsuarioServico servico)
        {
            Servico = servico;
        }

        public Task<UsuarioContrato> Handle(ObterUsuarioPorTelefoneRequest request, CancellationToken cancellationToken)
        {
            return Servico.ObterPorTelefoneAsync(request.Telefone, cancellationToken);
        }
    }
}