using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Modelos;

namespace FarmApp.Dominio.Interfaces.Conversores
{
    public interface ICertificaoConversor
    {
        CertificadoContrato ConverterEntidadeParaContrato(Certificado entidade);
    }
}