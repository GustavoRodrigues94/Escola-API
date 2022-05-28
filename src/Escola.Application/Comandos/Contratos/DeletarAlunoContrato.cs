using Flunt.Validations;

namespace Escola.Application.Comandos.Contratos
{
    public class DeletarAlunoContrato : Contract<DeletarAlunoComando>
    {
        public DeletarAlunoContrato(DeletarAlunoComando comando) =>
            Requires()
                .IsNotEmpty(comando.AlunoId, "AlunoId", "AlunoId é obrigatório");
    }
}
