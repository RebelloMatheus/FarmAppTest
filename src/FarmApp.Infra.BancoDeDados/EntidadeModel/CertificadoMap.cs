using FarmApp.Dominio.Modelos;
using FarmApp.Infra.BancoDeDados.EntidadeModel.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.BancoDeDados.EntidadeModel
{
    public class CertificadoMap : MappingBase<Certificado>
    {
        public override void Configure(EntityTypeBuilder<Certificado> builder)
        {
            builder.Property(x => x.Telefone)
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder.Property(x => x.Token)
                .HasMaxLength(4)
                .HasColumnType("varchar(4)");

            builder.Property(x => x.Validado)
                .HasDefaultValue(false);

            base.Configure(builder);
        }
    }
}