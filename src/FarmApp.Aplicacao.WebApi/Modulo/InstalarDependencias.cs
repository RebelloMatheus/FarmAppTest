using FarmApp.Aplicacao.WebApi.Conversores;
using FarmApp.Aplicacao.WebApi.Conversores.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstalarDependencias
    {
        public static void AdicionarServicoApi(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AdicionarRequisicoes(configuracao);
            servicos.AdicionarConversoresViewModel();
            servicos.AdicionarServicoSwagger();
        }

        public static void AdicionarConversoresViewModel(this IServiceCollection servicos)
        {
            servicos.TryAddScoped<ICertificadoContratoConversor, CertificadoContratoConversor>();
            servicos.TryAddScoped<IUsuarioContratoConversor, UsuarioContratoConversor>();
        }

        private static void AdicionarServicoSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Desafio de avaliação",
                    Version = "V1",
                    Description = "API conceitual de um desafio",
                    Contact = new OpenApiContact
                    {
                        Name = "Matheus Rebello",
                        Email = "matheus_rebello@yahoo.com.br",
                        Url = new Uri("https://www.linkedin.com/in/matheus-rebello-4a37a5b6/")
                    },
                });
            });
        }
    }
}