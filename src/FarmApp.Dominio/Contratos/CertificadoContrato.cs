namespace FarmApp.Dominio.Contratos
{
    public class CertificadoContrato
    {
        public string Telefone { get; }
        public string Token { get; }
        public bool Validado { get; }

        public CertificadoContrato(
            string telefone,
            string token,
            bool validado)
        {
            Telefone = telefone;
            Token = token;
            Validado = validado;
        }
    }
}