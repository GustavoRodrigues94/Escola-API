using System.Threading.Tasks;
using Escola.Application.Comandos;
using Escola.Core.Comandos.Contratos;
using Escola.Domain.Entidades;
using Escola.Domain.Repositorios;

namespace Escola.Application.Manipuladores
{
    public class AlunoComandoManipulador :
        IComandoManipulador<AdicionarAlunoComando>,
        IComandoManipulador<AtualizarAlunoComando>,
        IComandoManipulador<DeletarAlunoComando>
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoComandoManipulador(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task<ComandoResultado> Manipular(AdicionarAlunoComando comando)
        {
            var aluno = new Aluno(comando.Nome, comando.Sobrenome, comando.Email, comando.DataNascimento,
                comando.EscolaridadeId, comando.NomeHistoricoEscolar, comando.FormatoHistoricoEscolar,
                comando.Base64HistoricoEscolar);

            _alunoRepositorio.AdicionarAluno(aluno);

            var commitRealizado = await _alunoRepositorio.UnidadeDeTrabalho.Commit();

            return commitRealizado
                ? new ComandoResultado(true, "Sucesso ao adicionar aluno", aluno)
                : new ComandoResultado(false, "Ocorreu um erro ao adicionar aluno", null);
        }

        public async Task<ComandoResultado> Manipular(AtualizarAlunoComando comando)
        {
            var aluno = await _alunoRepositorio.ObterAlunoPorId(comando.AlunoId);
            if (aluno is null)
                return new ComandoResultado(false, "Aluno não encontrado", null);

            aluno.Atualizar(comando.Nome, comando.Sobrenome, comando.Email, comando.DataNascimento,
                comando.EscolaridadeId, comando.NomeHistoricoEscolar, comando.FormatoHistoricoEscolar,
                comando.Base64HistoricoEscolar);

            _alunoRepositorio.AtualizarAluno(aluno);

            var commitRealizado = await _alunoRepositorio.UnidadeDeTrabalho.Commit();

            return commitRealizado
                ? new ComandoResultado(true, "Sucesso ao atualizar aluno", aluno)
                : new ComandoResultado(false, "Ocorreu um erro ao atualizar aluno", null);
        }

        public async Task<ComandoResultado> Manipular(DeletarAlunoComando comando)
        {
            var aluno = await _alunoRepositorio.ObterAlunoPorId(comando.AlunoId);
            if(aluno is null) 
                return new ComandoResultado(false, "Aluno não encontrado", null);

            _alunoRepositorio.RemoverAluno(aluno);

            var commitRealizado = await _alunoRepositorio.UnidadeDeTrabalho.Commit();
            return commitRealizado
                ? new ComandoResultado(true, "Sucesso ao remover aluno", null)
                : new ComandoResultado(false, "Ocorreu um erro ao remover aluno", null);
        }
    }
}
