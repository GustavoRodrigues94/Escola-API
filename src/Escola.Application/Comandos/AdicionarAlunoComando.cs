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
    public class AdicionarAlunoComando : Notifiable<Notification>, IComando
    {
        public AdicionarAlunoComando(string nome, string sobrenome, string email, DateTime dataNascimento, Guid escolaridadeId, IFormFile historicoEscolarImagem)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
            HistoricoEscolarImagem = historicoEscolarImagem;

            ValidarHistoricoEscolarImagem(historicoEscolarImagem);
            AddNotifications(new AdicionarAlunoContrato(this));
        }

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
    }
}
