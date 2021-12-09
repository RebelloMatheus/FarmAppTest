using FarmApp.Dominio.Modelos.Base;
using FarmApp.Infra.BancoDeDados.Contexto.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FarmApp.Infra.BancoDeDados.Repositorio.Base
{
    public class RepositorioBase<TContextoTipo, TChavePrimaria>
        : IRepositorioBase<TChavePrimaria>, IDisposable
        where TContextoTipo : ContextoBase
    {
        protected readonly TContextoTipo contexto;

        public RepositorioBase(TContextoTipo contexto)
        {
            this.contexto = contexto;
        }

        public async Task AdicionarAsync<TEntidadeTipo>(TEntidadeTipo entidade) where TEntidadeTipo : EntidadeBase<TChavePrimaria>
        {
            await contexto.Set<TEntidadeTipo>().AddAsync(entidade);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<TEntidadeTipo> ConstruirConsultaAsync<TEntidadeTipo>() where TEntidadeTipo : EntidadeBase<TChavePrimaria>
            => contexto.Set<TEntidadeTipo>();

        public async Task<int> ContarTodosAsync<TEntidadeTipo>() where TEntidadeTipo : EntidadeBase<TChavePrimaria>
            => await contexto.Set<TEntidadeTipo>().CountAsync();

        public async Task<TEntidadeTipo> PrimeiroOuDefaultAsync<TEntidadeTipo>(Expression<Func<TEntidadeTipo, bool>> condicao) where TEntidadeTipo : EntidadeBase<TChavePrimaria>
            => await contexto.Set<TEntidadeTipo>().FirstOrDefaultAsync(condicao);

        public async Task<IList<TEntidadeTipo>> ObterTodosAsync<TEntidadeTipo>() where TEntidadeTipo : EntidadeBase<TChavePrimaria>
            => await contexto.Set<TEntidadeTipo>().ToListAsync();

        public async Task<IList<TEntidadeTipo>> ObterTodosAsync<TEntidadeTipo>(Expression<Func<TEntidadeTipo, bool>> condicao) where TEntidadeTipo : EntidadeBase<TChavePrimaria>
            => await contexto.Set<TEntidadeTipo>().Where(condicao).ToListAsync();

        public async Task<TEntidadeTipo> ObterPorIdAsync<TEntidadeTipo>(TChavePrimaria id)
            where TEntidadeTipo : EntidadeBase<TChavePrimaria>
            => await contexto.Set<TEntidadeTipo>().FindAsync(id);

        public async Task RemoveAsync<TEntidadeTipo>(TEntidadeTipo entidade) where TEntidadeTipo : EntidadeBase<TChavePrimaria>
        {
            contexto.Set<TEntidadeTipo>().Remove(entidade);
            await contexto.SaveChangesAsync();
        }

        public async Task RemoveIdAsync<TEntidadeTipo>(TChavePrimaria id) where TEntidadeTipo : EntidadeBase<TChavePrimaria>
        {
            var entidade = await ObterPorIdAsync<TEntidadeTipo>(id).ConfigureAwait(false);
            if (entidade != null)
            {
                contexto.Set<TEntidadeTipo>().Remove(entidade);
                await contexto.SaveChangesAsync();
            }
        }

        public async Task<int> ObterQuandoAsync<TEntidadeTipo>(Expression<Func<TEntidadeTipo, bool>> predicate) where TEntidadeTipo : EntidadeBase<TChavePrimaria>
            => await contexto.Set<TEntidadeTipo>().CountAsync(predicate);

        public async Task AtualizarAsync<TEntidadeTipo>(TEntidadeTipo entidade) where TEntidadeTipo : EntidadeBase<TChavePrimaria>
        {
            contexto.Set<TEntidadeTipo>().Update(entidade);
            await contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                contexto.Dispose();
        }
    }

    public class RepositorioBase<TContextoTipo> : RepositorioBase<TContextoTipo, Guid>, IRepositorioBase
        where TContextoTipo : ContextoBase
    {
        public RepositorioBase(TContextoTipo contexto) : base(contexto)
        { }
    }
}