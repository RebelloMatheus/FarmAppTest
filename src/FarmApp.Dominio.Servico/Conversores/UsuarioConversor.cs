using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Interfaces.Conversores;
using FarmApp.Dominio.Modelos;

namespace FarmApp.Dominio.Servico.Conversores
{
    internal class UsuarioConversor : IUsuarioConversor
    {
        public Usuario ConverterContratoParaEntidade(UsuarioContrato contrato)
        {
            return new Usuario(
                nome: contrato.Nome,
                cpf: contrato.Cpf,
                telefone: contrato.Telefone,
                email: contrato.Email,
                cep: contrato.Cep);
        }

        public UsuarioCadastradoContrato ConverterEntidadeParaUsuarioCadastradoContrato(Usuario entidade)
        {
            var usuarioContrato = ConverterEntidadeParaContrato(entidade);
            return new UsuarioCadastradoContrato(usuarioContrato, false);
        }

        public UsuarioContrato ConverterEntidadeParaContrato(Usuario entidade)
        {
            return new UsuarioContrato(
                   id: entidade.Id,
                   nome: entidade.Nome,
                   cpf: entidade.Cpf,
                   telefone: entidade.Telefone,
                   email: entidade.Email,
                   cep: entidade.Cep);
        }
    }
}