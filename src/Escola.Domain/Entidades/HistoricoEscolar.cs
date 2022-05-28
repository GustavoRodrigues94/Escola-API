using System.Collections.Generic;
using Escola.Core.DominioBase;
using Escola.Domain.Enums;

namespace Escola.Domain.Entidades
{
    public class HistoricoEscolar : EntidadeBase
    {
        public HistoricoEscolar(string nome, FormatoHistoricoEnum formato, string historicoBase64)
        {
            Nome = nome;
            Formato = formato;
            HistoricoBase64 = historicoBase64;
            _alunos = new List<Aluno>();
        }

        public string Nome { get; private set; }
        public FormatoHistoricoEnum Formato { get; private set; }
        public string HistoricoBase64 { get; private set; }

        private readonly List<Aluno> _alunos;
        public IEnumerable<Aluno> Alunos => _alunos;

        public void Atualizar(string nomeHistoricoEscolar, FormatoHistoricoEnum formatoHistoricoEscolar, string historicoEscolarBase64)
        {
            Nome = nomeHistoricoEscolar;
            Formato = formatoHistoricoEscolar;
            HistoricoBase64 = historicoEscolarBase64;
        }
    }
}
