using FarmApp.Dominio.Contratos;
using MediatR;
using System;

namespace FarmApp.Dominio.Mediator.Mediators.Requests.Consultar
{
    public class ObterUsuarioPorIdRequest : IRequest<UsuarioContrato>
    {
        public Guid Id { get; private set; }

        public ObterUsuarioPorIdRequest(Guid id)
        {
            Id = id;
        }
    }
}