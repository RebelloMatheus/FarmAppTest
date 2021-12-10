using FluentValidation;

namespace FarmApp.Aplicacao.WebApi.Extensoes
{
    public abstract class AbstractValidatorBase<T> : AbstractValidator<T>
    {
        protected string TermoPadraoClasse = nameof(T);

        protected string EhInvalido(string parametro) => $"{TermoPadraoClasse} sem {parametro} valido.";

        protected string EhObrigatorio(string parametro) => $"{parametro} é obrigatório";
    }
}