using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using CountryData.Bogus;
using FarmApp.Dominio.Contratos;
using FarmApp.Dominio.Modelos;
using System;

namespace FarmApp.Testes.Test.Fixtures
{
    internal class CertificadoFixture
    {
        public Certificado GerarInvalidado()
        {
            return new Faker<Certificado>(locale: "pt_BR")
                .CustomInstantiator(f =>
                {
                    return new Certificado(
                        telefone: f.Person.Phone,
                        token: f.System.ApplePushToken(),
                        validado: false);
                });
        }

        public Certificado GerarValidado()
        {
            return new Faker<Certificado>(locale: "pt_BR")
                .CustomInstantiator(f =>
                {
                    return new Certificado(
                        telefone: f.Person.Phone,
                        token: f.System.ApplePushToken(),
                        validado: true);
                });
        }
    }

    internal class UsuarioContratoFixture
    {
        public UsuarioContrato GerarValido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<UsuarioContrato>(locale: "pt_BR")
                .CustomInstantiator(f =>
                {
                    var nome = f.Name.FirstName(genero);
                    var sobrenome = f.Name.LastName(genero);
                    var email = f.Internet.Email(firstName: nome.ToLower(), lastName: sobrenome.ToLower());

                    return new UsuarioContrato(
                        id: Guid.NewGuid(),
                        nome: nome,
                        cpf: f.Person.Cpf(),
                        telefone: f.Person.Phone,
                        email: email,
                        cep: f.Country().Brazil().PostCode());
                });

            return cliente;
        }
    }

    internal class UsuarioFixture
    {
        public Usuario GerarValido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var sobrenome = string.Empty;
            var nome = string.Empty;

            var cliente = new Faker<Usuario>(locale: "pt_BR")
                .CustomInstantiator(f =>
                {
                    nome = f.Name.FirstName(genero);
                    sobrenome = f.Name.LastName(genero);

                    return new Usuario(
                    nome,
                    f.Person.Cpf(),
                    f.Person.Phone,
                    "",
                    f.Country().Brazil().PostCode());
                })
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(firstName: nome.ToLower(), lastName: sobrenome.ToLower()));

            return cliente;
        }
    }
}