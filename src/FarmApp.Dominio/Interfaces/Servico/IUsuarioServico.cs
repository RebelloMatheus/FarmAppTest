using FarmApp.Dominio.Contratos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FarmApp.Dominio.Interfaces.Servico
{
    public interface IUsuarioServico
    {
        Task<UsuarioCadastradoContrato> AdicionarAsync(UsuarioContrato contrato, CancellationToken cancellationToken);

        Task<UsuarioContrato> ObterPorTelefoneAsync(string telefone, CancellationToken cancellationToken);

        Task<UsuarioContrato> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
    }
}