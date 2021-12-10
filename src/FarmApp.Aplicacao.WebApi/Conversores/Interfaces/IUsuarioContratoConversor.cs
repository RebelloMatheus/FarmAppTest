using FarmApp.Aplicacao.WebApi.ViewModel;
using FarmApp.Dominio.Contratos;

namespace FarmApp.Aplicacao.WebApi.Conversores.Interfaces
{
    public interface IUsuarioContratoConversor
    {
        UsuarioContrato ConverterViewModelParaContrato(UsuarioViewModel viewModel);

        UsuarioViewModel ConverterContratoParaViewModel(UsuarioContrato contrato);
    }
}