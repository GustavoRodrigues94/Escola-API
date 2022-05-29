using System;
using Escola.Core.DominioBase;
using Escola.Domain.Enums;

namespace Escola.Domain.Entidades
{
    public class HistoricoEscolar : EntidadeBase
    {
        public HistoricoEscolar(string nome, FormatoHistoricoEnum formato, string historicoBase64, Guid alunoId)
        {
            Nome = nome;
            Formato = formato;
            HistoricoBase64 = historicoBase64;
            AlunoId = alunoId;
        }

        public string Nome { get; private set; }
        public FormatoHistoricoEnum Formato { get; private set; }
        public string HistoricoBase64 { get; private set; }

        public Guid AlunoId { get; private set; }
        public Aluno Aluno { get; private set; }

        public void Atualizar(string nomeHistoricoEscolar, FormatoHistoricoEnum formatoHistoricoEscolar, string historicoEscolarBase64)
        {
            Nome = nomeHistoricoEscolar;
            Formato = formatoHistoricoEscolar;
            HistoricoBase64 = historicoEscolarBase64;
        }
    }
}
