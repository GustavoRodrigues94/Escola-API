using System;
using Escola.Domain.Enums;

namespace Escola.Application.Consultas.ViewModels
{
    public class HistoricoEscolarViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public FormatoHistoricoEnum FormatoHistoricoEnum { get; set; }
        public string FormatoHistoricoDescricao { get; set; }
        public string HistoricoBase64 { get; set; }
    }
}
