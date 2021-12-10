using FarmApp.Dominio.Contratos;
using MediatR;

namespace FarmApp.Dominio.Mediator.Mediators.Requests.Consultar
{
    public class ObterUsuarioPorTelefoneRequest : IRequest<UsuarioContrato>
    {
        public string Telefone { get; private set; }

        public ObterUsuarioPorTelefoneRequest(string telefone)
        {
            Telefone = telefone;
        }
    }
}