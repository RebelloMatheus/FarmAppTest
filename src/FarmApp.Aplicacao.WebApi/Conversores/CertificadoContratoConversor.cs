using FarmApp.Aplicacao.WebApi.Conversores.Interfaces;
using FarmApp.Aplicacao.WebApi.ViewModel;
using FarmApp.Dominio.Contratos;

namespace FarmApp.Aplicacao.WebApi.Conversores
{
    internal class CertificadoContratoConversor : ICertificadoContratoConversor
    {
        public CertificadoViewModel ConverterContratoParaViewModel(CertificadoContrato contrato)
        {
            return new CertificadoViewModel
            {
                Telefone = contrato.Telefone,
                Token = contrato.Token,
                Validado = contrato.Validado
            };
        }
    }
}