namespace FarmApp.Dominio.Contratos
{
    public class UsuarioCadastradoContrato
    {
        public UsuarioContrato Usuario { get; }

        public bool CadastroFinalizado { get; }

        public UsuarioCadastradoContrato(
            UsuarioContrato usuario,
            bool cadastroFinalizado)
        {
            Usuario = usuario;
            CadastroFinalizado = cadastroFinalizado;
        }
    }
}