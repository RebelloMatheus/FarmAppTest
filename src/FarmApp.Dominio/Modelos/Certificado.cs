using FarmApp.Dominio.Modelos.Base;

namespace FarmApp.Dominio.Modelos
{
    public class Certificado : EntidadeBase
    {
        public string Telefone { get; private set; }
        public string Token { get; private set; }
        public bool Validado { get; private set; } = false;

        public Certificado(
            string telefone,
            string token)
        {
            Telefone = telefone;
            Token = token;
        }

        public Certificado(
            string telefone,
            string token,
            bool validado) : this(telefone, token)
        {
            Validado = validado;
        }

        public void SetValidado(bool validado)
        {
            Validado = validado;
        }

        public void SetToken(string token)
        {
            Token = token;
        }
    }
}