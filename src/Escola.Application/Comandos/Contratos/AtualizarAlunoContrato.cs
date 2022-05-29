using System;
using Flunt.Validations;

namespace Escola.Application.Comandos.Contratos
{
    public class AtualizarAlunoContrato : Contract<AtualizarAlunoComando>
    {
        public AtualizarAlunoContrato(AtualizarAlunoComando comando) =>
            Requires()
                .IsNotEmpty(comando.AlunoId, "AlunoId", "AlunoId é obrigatório")
                .IsNotNullOrEmpty(comando.Nome, "Nome", "Nome é obrigatório")
                .IsNotNullOrEmpty(comando.Sobrenome, "Sobrenome", "Sobrenome é obrigatório")
                .IsEmail(comando.Email, "Email", "Email inválido")
                .IsLowerOrEqualsThan(comando.DataNascimento.Date, DateTime.UtcNow.Date, "Data de nascimento deve ser menor que a data de hoje")
                .IsNotEmpty(comando.EscolaridadeId, "EscolaridadeId", "EscolaridadeId é obrigatório");
    }
}
