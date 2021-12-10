using FarmApp.Aplicacao.WebApi.Extensoes;
using FluentValidation;

namespace FarmApp.Aplicacao.WebApi.ViewModel
{
    public class UsuarioViewModel
    {
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
    }

    internal class UsuarioValidacao : AbstractValidatorBase<UsuarioViewModel>
    {
        protected string TermoPadraoClasse = "Usuário";

        public UsuarioValidacao()
        {
            RuleFor(r => r.Nome)
                .NotNull().WithMessage(w => EhObrigatorio(nameof(w.Nome)))
                .NotEmpty().WithMessage(w => EhObrigatorio(nameof(w.Nome)))
                .Length(3, 100).WithMessage("Nome precisa ter no mínimo 3 caracter e máximo de 100 caracter");

            RuleFor(u => u.Cpf)
                .NotNull().WithMessage("CPF é obrigatório")
                .NotEmpty().WithMessage("CPF é obrigatório")
                .CPF().WithMessage("CPF inválido");

            RuleFor(u => u.Email)
                .NotNull().WithMessage(w => EhObrigatorio(nameof(w.Email)))
                .NotEmpty().WithMessage(w => EhObrigatorio(nameof(w.Email)))
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(u => u.Telefone)
                .NotNull().WithMessage(w => EhObrigatorio(nameof(w.Telefone)))
                .NotEmpty().WithMessage(w => EhObrigatorio(nameof(w.Telefone)))
                .Telefone().WithMessage("Informe um número de telefone válido com DDD");

            RuleFor(r => r.Cep)
                .NotNull().WithMessage(w => EhObrigatorio(nameof(w.Cep)))
                .NotEmpty().WithMessage(w => EhObrigatorio(nameof(w.Cep)))
                .CEP().WithMessage(w => EhInvalido(nameof(w.Cep)));
        }
    }
}