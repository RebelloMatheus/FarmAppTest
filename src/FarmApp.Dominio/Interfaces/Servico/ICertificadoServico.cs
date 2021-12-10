using FarmApp.Dominio.Contratos;
using System.Threading;
using System.Threading.Tasks;

namespace FarmApp.Dominio.Interfaces.Servico
{
    public interface ICertificadoServico
    {
        Task<CertificadoContrato> VerificarAsync(string token, CancellationToken cancellationToken);

        Task InserirAsync(string telefone, CancellationToken cancellationToken);
    }
}