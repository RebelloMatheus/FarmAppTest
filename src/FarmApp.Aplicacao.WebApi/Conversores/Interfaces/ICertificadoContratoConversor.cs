using FarmApp.Aplicacao.WebApi.ViewModel;
using FarmApp.Dominio.Contratos;

namespace FarmApp.Aplicacao.WebApi.Conversores.Interfaces
{
    public interface ICertificadoContratoConversor
    {
        CertificadoViewModel ConverterContratoParaViewModel(CertificadoContrato contrato);
    }
}