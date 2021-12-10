using FarmApp.Dominio.Modelos.Base;

namespace FarmApp.Dominio.Modelos
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Cep { get; private set; }

        protected Usuario()
        { }

        public Usuario(
            string nome,
            string cpf,
            string telefone,
            string email,
            string cep)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Cep = cep;
        }
    }
}