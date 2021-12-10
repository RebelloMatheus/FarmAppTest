using System;

namespace FarmApp.Dominio.Contratos
{
    public class UsuarioContrato
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string Cpf { get; }
        public string Telefone { get; }
        public string Email { get; }
        public string Cep { get; }

        public UsuarioContrato(
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

        public UsuarioContrato(
            Guid id,
            string nome,
            string cpf,
            string telefone,
            string email,
            string cep)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Cep = cep;
        }
    }
}