using System;
using System.Linq;
using System.Threading.Tasks;
using Escola.Core.RepositorioBase;
using Escola.Domain.Entidades;

namespace Escola.Domain.Repositorios
{
    public interface IAlunoRepositorio : IRepositorio<Aluno>
    {
        void AdicionarAluno(Aluno aluno);
        void AtualizarAluno(Aluno aluno);
        void RemoverAluno(Aluno aluno);

        Task<Aluno> ObterAlunoPorId(Guid alunoId);
        IQueryable<Aluno> ObterAlunos();
    }
}
