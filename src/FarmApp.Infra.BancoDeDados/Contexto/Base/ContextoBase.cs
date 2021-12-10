using Microsoft.EntityFrameworkCore;

namespace FarmApp.Infra.BancoDeDados.Contexto.Base
{
    public abstract class ContextoBase : DbContext, IContextoBase
    {
        public abstract string ContextoNome { get; }

        protected ContextoBase(DbContextOptions options) : base(options)
        { }
    }
}