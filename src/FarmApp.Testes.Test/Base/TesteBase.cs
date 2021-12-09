using FarmApp.Infra.BancoDeDados.Contexto.Base;
using FarmApp.Infra.BancoDeDados.Repositorio.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmApp.Testes.Test.Base
{
    public abstract class TesteBase
    {
        private readonly IServiceCollection serviceCollection;
        private IServiceScopeFactory serviceScopeFactory;
        private Type contextoEFTest;
        private DbContextOptions<ContextoBase> dbContextoOptions;

        protected IConfiguration config => new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .Build();

        protected IServiceScopeFactory ServiceScope
        {
            get
            {
                var contexto = Activator.CreateInstance(contextoEFTest, dbContextoOptions);
                serviceCollection.AddScoped(_ => contexto);
                return serviceScopeFactory;
            }
            private set => value = serviceScopeFactory;
        }

        protected IRepositorioBase Repositorio { get; set; }
        protected IServiceProvider Servico;

        protected TesteBase()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(_ => config);
        }

        [SetUp]
        public void SetUpBase()
        {
            dbContextoOptions = new DbContextOptionsBuilder<ContextoBase>()
                .UseInMemoryDatabase(databaseName: nameof(contextoEFTest))
                .Options;

            AdicionarServico(serviceCollection, config);

            IniciarServiceProviderContexto();

            SetUp();
        }

        private void IniciarServiceProviderContexto()
        {
            Servico = serviceCollection.BuildServiceProvider();

            if (contextoEFTest != null)
            {
                var contexto = (ContextoBase)Servico.GetService(contextoEFTest);
                contexto.Database.EnsureDeleted();
                contexto.Database.EnsureCreated();

                Repositorio = ObterServico<IRepositorioBase>();
            }

            serviceScopeFactory = Servico.GetService<IServiceScopeFactory>();
        }

        protected abstract void AdicionarServico(IServiceCollection servicos, IConfiguration configuracao);

        protected abstract void SetUp();

        protected void AdicionarBancoDeDadosTeste<TContexto>() where TContexto : ContextoBase
        {
            AdicionarBancoDeDadosTeste<TContexto, Guid>();
        }

        protected void AdicionarBancoDeDadosTeste<TContexto, TChavePrimaria>() where TContexto : ContextoBase
        {
            contextoEFTest = typeof(TContexto);
            var contexto = (TContexto)Activator.CreateInstance(contextoEFTest, dbContextoOptions);
            serviceCollection.AddScoped(_ => contexto);
            serviceCollection.AddSingleton<IRepositorioBase<TChavePrimaria>, RepositorioBase<TContexto, TChavePrimaria>>();
            serviceCollection.AddSingleton<IRepositorioBase, RepositorioBase<TContexto>>();
        }

        protected T ObterServico<T>()
        {
            return Servico.GetService<T>();
        }

        protected IEnumerable<T> ObterServicos<T>()
        {
            return Servico.GetServices<T>();
        }

        protected T ObterServico<T>(Type type)
        {
            return (T)Servico.GetService(type);
        }

        protected void SubstituirServico<T>() where T : class
        {
            SubstituirServico<T>(Substitute.For<T>());
        }

        protected void SubstituirServico<T>(T instancia)
        {
            var descritorRemove = serviceCollection.FirstOrDefault(x => x.ServiceType == typeof(T));
            if (descritorRemove == null)
                return;

            serviceCollection.Remove(descritorRemove);

            var descritorAdicionar = new ServiceDescriptor(typeof(T), instancia);

            serviceCollection.Add(descritorAdicionar);

            IniciarServiceProviderContexto();
        }

        [TearDown]
        public void TearDownAttribute()
        {
            TearDown();
        }

        public virtual void TearDown()
        { }
    }
}