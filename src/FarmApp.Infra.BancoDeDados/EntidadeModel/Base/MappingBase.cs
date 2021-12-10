using FarmApp.Dominio.Modelos.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.BancoDeDados.EntidadeModel.Base
{
    public class MappingBase<TEntidadeTipo, T>
        : IEntityTypeConfiguration<TEntidadeTipo> where TEntidadeTipo : EntidadeBase<T>
    {
        private string NomeTabela => typeof(TEntidadeTipo).Name;

        public virtual void Configure(EntityTypeBuilder<TEntidadeTipo> builder)
        {
            builder.ToTable(NomeTabela);

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                .HasName($"IX_{NomeTabela}_Id");
        }
    }

    public class MappingBase<TEntidadeTipo> : IEntityTypeConfiguration<TEntidadeTipo> where TEntidadeTipo : EntidadeBase
    {
        private string NomeTabela => typeof(TEntidadeTipo).Name;

        public virtual void Configure(EntityTypeBuilder<TEntidadeTipo> builder)
        {
            builder.ToTable(NomeTabela);

            builder.HasKey(x => x.Id)
                .HasName($"IX_{NomeTabela}_Id");
        }
    }
}