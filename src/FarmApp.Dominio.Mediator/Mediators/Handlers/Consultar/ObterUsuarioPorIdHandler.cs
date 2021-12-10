using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Interfaces.Servico;
using FarmApp.Dominio.Mediator.Mediators.Requests.Consultar;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FarmApp.Dominio.Mediator.Mediators.Handlers.Consultar
{
    internal class ObterUsuarioPorIdHandler :
        IRequestHandler<ObterUsuarioPorIdRequest, UsuarioContrato>
    {
        private readonly IUsuarioServico Servico;

        public ObterUsuarioPorIdHandler(IUsuarioServico servico)
        {
            Servico = servico;
        }

        public Task<UsuarioContrato> Handle(ObterUsuarioPorIdRequest request, CancellationToken cancellationToken)
        {
            return Servico.ObterPorIdAsync(request.Id, cancellationToken);
        }
    }
}