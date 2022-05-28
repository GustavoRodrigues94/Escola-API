using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Escola.Application.Consultas.ViewModels;

namespace Escola.Application.Consultas
{
    public interface IAlunoConsultas
    {
        Task<AlunoViewModel> ObterAlunoPorId(Guid alunoId);
        Task<IEnumerable<AlunoViewModel>> ObterAlunos();
    }
}
