using System;
using Escola.Application.Comandos.Contratos;
using Escola.Core.Comandos.Contratos;
using Escola.Core.Utilitarios;
using Escola.Core.Utilitarios.DTOs;
using Escola.Domain.Enums;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;

namespace Escola.Application.Comandos
{
    public class AtualizarAlunoComando : Notifiable<Notification>, IComando
    {
        public AtualizarAlunoComando(Guid id, string nome, string sobrenome, string email, DateTime dataNascimento, Guid escolaridadeId)
        {
            AlunoId = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
        }

        public Guid AlunoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid EscolaridadeId { get; set; }
        public IFormFile HistoricoEscolarImagem { get; set; }
        public string NomeHistoricoEscolar { get; private set; }
        public FormatoHistoricoEnum FormatoHistoricoEscolar { get; private set; }
        public string Base64HistoricoEscolar { get; private set; }

        private void ValidarHistoricoEscolarImagem(IFormFile historicoEscolarImagem)
        {
            var formFileDTO = FormFileManipulador.ObterFormFileDetalhes(historicoEscolarImagem);
            if (!ValidarHistoricoEscolar(formFileDTO))
                AddNotification("HistoricoEscolarImagem", "Formato incorreto");

            NomeHistoricoEscolar = formFileDTO.NomeArquivo;
            FormatoHistoricoEscolar = formFileDTO.FormatoArquivo == FormatoHistoricoEnum.Pdf.ObterDescricaoEnum()
                ? FormatoHistoricoEnum.Pdf
                : FormatoHistoricoEnum.Doc;
            Base64HistoricoEscolar = formFileDTO.Base64Arquivo;
        }

        private static bool ValidarHistoricoEscolar(FormFileDTO formFileDTO) =>
            formFileDTO != null &&
            (formFileDTO.FormatoArquivo.Contains(FormatoHistoricoEnum.Doc.ObterDescricaoEnum())
             || formFileDTO.FormatoArquivo.Contains(FormatoHistoricoEnum.Pdf.ObterDescricaoEnum()));

        public void AdicionarHistoricoEscolarImagem(IFormFile historicoEscolar)
        {
            if (historicoEscolar is null)
            {
                AddNotifications(new AtualizarAlunoContrato(this));
                return;
            }

            HistoricoEscolarImagem = historicoEscolar;
            ValidarHistoricoEscolarImagem(historicoEscolar);
            AddNotifications(new AtualizarAlunoContrato(this));
        }
    }
}
