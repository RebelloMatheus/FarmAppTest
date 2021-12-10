using FarmApp.Dominio.Modelos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FarmApp.Infra.BancoDeDados.Repositorio.Base
{
    public interface IRepositorioBase<TChavePrimaria>
    {
        IQueryable<TEntidadeBase> ConstruirConsultaAsync<TEntidadeBase>()
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task<IList<TEntidadeBase>> ObterTodosAsync<TEntidadeBase>()
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task<TEntidadeBase> ObterPorIdAsync<TEntidadeBase>(TChavePrimaria id)
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task<IList<TEntidadeBase>> ObterTodosAsync<TEntidadeBase>(Expression<Func<TEntidadeBase, bool>> condicao)
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task<TEntidadeBase> PrimeiroOuPadraoAsync<TEntidadeBase>(Expression<Func<TEntidadeBase, bool>> condicao)
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task AdicionarAsync<TEntidadeBase>(TEntidadeBase entidade)
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task AtualizarAsync<TEntidadeBase>(TEntidadeBase entidade)
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task RemoveAsync<TEntidadeBase>(TEntidadeBase entidade)
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task RemoveIdAsync<TEntidadeBase>(TChavePrimaria id)
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task<int> ContarTodosAsync<TEntidadeBase>()
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;

        Task<int> ContarAsync<TEntidadeBase>(Expression<Func<TEntidadeBase, bool>> predicate)
            where TEntidadeBase : EntidadeBase<TChavePrimaria>;
    }

    public interface IRepositorioBase : IRepositorioBase<Guid>
    { }
}