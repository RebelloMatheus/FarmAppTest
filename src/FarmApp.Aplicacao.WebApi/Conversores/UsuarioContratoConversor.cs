using FarmApp.Aplicacao.WebApi.Conversores.Interfaces;
using FarmApp.Aplicacao.WebApi.ViewModel;
using FarmApp.Dominio.Contratos;

namespace FarmApp.Aplicacao.WebApi.Conversores
{
    internal class UsuarioContratoConversor : IUsuarioContratoConversor
    {
        public UsuarioViewModel ConverterContratoParaViewModel(UsuarioContrato contrato)
        {
            return new UsuarioViewModel
            {
                Telefone = contrato.Telefone,
                Nome = contrato.Nome,
                Cpf = contrato.Cpf,
                Email = contrato.Email,
                Cep = contrato.Cep
            };
        }

        public UsuarioContrato ConverterViewModelParaContrato(UsuarioViewModel viewModel)
        {
            return new UsuarioContrato(
                nome: viewModel.Nome,
                cpf: viewModel.Cpf,
                telefone: viewModel.Telefone,
                email: viewModel.Email,
                cep: viewModel.Cep);
        }
    }
}