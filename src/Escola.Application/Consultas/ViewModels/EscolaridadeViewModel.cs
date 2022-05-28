using System;
using Escola.Domain.Enums;

namespace Escola.Application.Consultas.ViewModels
{
    public class EscolaridadeViewModel
    {
        public Guid Id { get; set; }
        public EscolaridadeEnum EscolaridadeEnum { get; set; }
        public string EscolaridadeDescricao { get; set; }
    }
}
