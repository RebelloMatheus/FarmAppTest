using FarmApp.Dominio.Modelos;
using FarmApp.Infra.BancoDeDados.EntidadeModel.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.BancoDeDados.EntidadeModel
{
    public class UsuarioMap : MappingBase<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Cpf)
                .HasMaxLength(14)
                .HasColumnType("varchar(14)");

            builder.Property(x => x.Telefone)
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Cep)
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            base.Configure(builder);
        }
    }
}