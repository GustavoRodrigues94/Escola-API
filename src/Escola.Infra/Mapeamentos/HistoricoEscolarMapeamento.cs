using Escola.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Mapeamentos
{
    public class HistoricoEscolarMapeamento : IEntityTypeConfiguration<HistoricoEscolar>
    {
        public void Configure(EntityTypeBuilder<HistoricoEscolar> builder)
        {
            builder.ToTable("HistoricoEscolar");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.HistoricoBase64).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.Formato).HasConversion<string>().HasColumnType("varchar(20)").IsRequired();
        }
    }
}
