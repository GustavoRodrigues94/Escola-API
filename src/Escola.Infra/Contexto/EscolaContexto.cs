using System.Threading.Tasks;
using Escola.Core.RepositorioBase;
using Escola.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Contexto
{
    public class EscolaContexto : DbContext, IUnidadeDeTrabalho
    {
        public EscolaContexto(DbContextOptions opcoes) : base(opcoes) { }

        public DbSet<Aluno> Aluno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EscolaContexto).Assembly);
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;

            return sucesso;
        }
    }
}
