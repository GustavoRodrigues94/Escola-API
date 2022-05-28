using System;
using Flunt.Validations;

namespace Escola.Application.Comandos.Contratos
{
    public class AdicionarAlunoContrato : Contract<AdicionarAlunoComando>
    {
        public AdicionarAlunoContrato(AdicionarAlunoComando comando) =>
            Requires()
                .IsNotNullOrEmpty(comando.Nome, "Nome", "Nome é obrigatório")
                .IsNotNullOrEmpty(comando.Sobrenome, "Sobrenome", "Sobrenome é obrigatório")
                .IsEmail(comando.Email, "Email", "Email inválido")
                .IsLowerThan(comando.DataNascimento.Date, DateTime.UtcNow.Date, "Data de nascimento deve ser menor que a data de hoje")
                .IsNotEmpty(comando.EscolaridadeId, "EscolaridadeId", "EscolaridadeId é obrigatório")
                .IsNotNull(comando.HistoricoEscolarImagem, "HistoricoEscolarImagem", "HistoricoEscolarImagem é obrigatório")
                .IsNotNullOrEmpty(comando.NomeHistoricoEscolar, "NomeHistoricoEscolar", "NomeHistoricoEscolar é obrigatório")
                .IsNotNullOrEmpty(comando.FormatoHistoricoEscolar.ToString(), "FormatoHistoricoEscolar", "FormatoHistoricoEscolar é obrigatório")
                .IsNotNullOrEmpty(comando.Base64HistoricoEscolar, "Base64HistoricoEscolar", "Base64HistoricoEscolar é obrigatório");
    }
}
