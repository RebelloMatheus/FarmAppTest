using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Modelos;

namespace FarmApp.Dominio.Interfaces.Conversores
{
    public interface IUsuarioConversor
    {
        Usuario ConverterContratoParaEntidade(UsuarioContrato contrato);

        UsuarioCadastradoContrato ConverterEntidadeParaUsuarioCadastradoContrato(Usuario entidade);

        UsuarioContrato ConverterEntidadeParaContrato(Usuario usuario);
    }
}