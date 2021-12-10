using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Interfaces.Conversores;
using FarmApp.Dominio.Modelos;

namespace FarmApp.Dominio.Servico.Conversores
{
    internal class CertificaoConversor : ICertificaoConversor
    {
        public CertificadoContrato ConverterEntidadeParaContrato(Certificado entidade)
        {
            return new CertificadoContrato(
                telefone: entidade.Telefone,
                token: entidade.Token,
                validado: entidade.Validado);
        }
    }
}