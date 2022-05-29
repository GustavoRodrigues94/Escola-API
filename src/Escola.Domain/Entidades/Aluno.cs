using System;
using Escola.Core.DominioBase;
using Escola.Domain.Enums;

namespace Escola.Domain.Entidades
{
    public class Aluno : EntidadeBase, IRaizAgregacao
    {
        protected Aluno() { }

        public Aluno(string nome, string sobrenome, string email, DateTime dataNascimento, Guid escolaridadeId,
            string nomeHistoricoEscolar, FormatoHistoricoEnum formatoHistoricoEscolar, string historicoEscolarBase64)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;

            AdicionarHistoricoEscolar(nomeHistoricoEscolar, formatoHistoricoEscolar, historicoEscolarBase64);
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Guid EscolaridadeId { get; private set; }
        public Escolaridade Escolaridade { get; private set; }

        public HistoricoEscolar HistoricoEscolar { get; private set; }

        private void AdicionarHistoricoEscolar(string nomeHistoricoEscolar, FormatoHistoricoEnum formatoHistoricoEscolar, string historicoEscolarBase64)
        {
            var historicoEscolar = new HistoricoEscolar(nomeHistoricoEscolar, formatoHistoricoEscolar, historicoEscolarBase64, Id);
            HistoricoEscolar = historicoEscolar;
        }

        public void Atualizar(string nome, string sobrenome, string email, DateTime dataNascimento, Guid escolaridadeId,
            string nomeHistoricoEscolar, FormatoHistoricoEnum formatoHistoricoEscolar, string historicoEscolarBase64)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;

            if (string.IsNullOrEmpty(historicoEscolarBase64)) return;

            AtualizarHistoricoEscolar(nomeHistoricoEscolar, formatoHistoricoEscolar, historicoEscolarBase64);
        }

        private void AtualizarHistoricoEscolar(string nomeHistoricoEscolar, FormatoHistoricoEnum formatoHistoricoEscolar, string historicoEscolarBase64)
        {
            HistoricoEscolar?.Atualizar(nomeHistoricoEscolar, formatoHistoricoEscolar, historicoEscolarBase64);
        }
    }
}
