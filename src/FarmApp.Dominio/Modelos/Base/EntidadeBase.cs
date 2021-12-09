using FarmApp.Dominio.Interfaces.Modelos;
using System;

namespace FarmApp.Dominio.Modelos.Base
{
    public abstract class EntidadeBase<TChavePrimaria> : IEntidadeBase<TChavePrimaria>
    {
        public TChavePrimaria Id { get; protected set; }
    }

    public abstract class EntidadeBase : EntidadeBase<Guid>, IEntidadeBase
    { }
}