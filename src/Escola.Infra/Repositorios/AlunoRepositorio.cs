using System;
using System.Linq;
using System.Threading.Tasks;
using Escola.Core.RepositorioBase;
using Escola.Domain.Entidades;
using Escola.Domain.Repositorios;
using Escola.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly EscolaContexto _contexto;
        public IUnidadeDeTrabalho UnidadeDeTrabalho => _contexto;

        public AlunoRepositorio(EscolaContexto contexto)
        {
            _contexto = contexto;
        }

        public void AdicionarAluno(Aluno aluno) => _contexto.Aluno.Add(aluno);

        public void AtualizarAluno(Aluno aluno) => _contexto.Update(aluno);

        public void RemoverAluno(Aluno aluno) => _contexto.Remove(aluno);

        public async Task<Aluno> ObterAlunoPorId(Guid alunoId) =>
            await _contexto.Aluno
                .Include(x => x.HistoricoEscolar)
                .Include(x => x.Escolaridade)
                .FirstOrDefaultAsync(x => x.Id == alunoId);

        public IQueryable<Aluno> ObterAlunos() =>
            _contexto.Aluno
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.HistoricoEscolar)
                .Include(x => x.Escolaridade)
                .AsQueryable();

        public IQueryable<Escolaridade> ObterListaEscolaridade() =>
            _contexto.Escolaridade
                .AsNoTrackingWithIdentityResolution()
                .AsQueryable();

        public void Dispose() => _contexto?.Dispose();
    }
}
