using System;

namespace Escola.Application.Consultas.ViewModels
{
    public class AlunoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EscolaridadeViewModel Escolaridade { get; set; }
        public HistoricoEscolarViewModel HistoricoEscolar { get; set; }
    }
}
