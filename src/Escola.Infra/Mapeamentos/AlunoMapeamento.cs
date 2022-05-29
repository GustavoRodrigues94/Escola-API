using Escola.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Mapeamentos
{
    public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.Sobrenome).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("date").IsRequired();
            builder.HasOne(a => a.Escolaridade).WithMany(e => e.Alunos).HasForeignKey(a => a.EscolaridadeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.HistoricoEscolar).WithMany(h => h.Alunos).HasForeignKey(a => a.HistoricoEscolarId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
