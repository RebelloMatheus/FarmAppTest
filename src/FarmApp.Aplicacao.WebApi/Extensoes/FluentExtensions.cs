using FluentValidation;
using System.Text.RegularExpressions;

namespace FarmApp.Aplicacao.WebApi.Extensoes
{
    public static class FluentExtensions
    {
        private static readonly string StringRegexTelefone = @"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$";
        private static readonly string StringRegexCEP = "[0-9]{5}-[0-9]{3}";

        public static IRuleBuilderOptions<T, TElemento> Telefone<T, TElemento>(this IRuleBuilder<T, TElemento> ruleBuilder)
        {
            return ruleBuilder.Must((t, elemento) => Regex.IsMatch(elemento.ToString(), StringRegexTelefone));
        }

        public static IRuleBuilderOptions<T, TElemento> CPF<T, TElemento>(this IRuleBuilder<T, TElemento> ruleBuilder)
        {
            return ruleBuilder.Must((t, elemento) => ValidaCPF(elemento.ToString()));
        }

        public static IRuleBuilderOptions<T, TElemento> CEP<T, TElemento>(this IRuleBuilder<T, TElemento> ruleBuilder)
        {
            return ruleBuilder.Must((t, elemento) => ValidaCep(elemento.ToString()));
        }

        private static bool ValidaCPF(string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return false;

            string valor = termo.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

        private static bool ValidaCep(string termo)
        {
            if (string.IsNullOrEmpty(termo))
                return false;

            if (termo.Length == 8)
                termo = termo.Substring(0, 5) + "-" + termo.Substring(5, 3);

            return Regex.IsMatch(termo, StringRegexCEP);
        }
    }
}