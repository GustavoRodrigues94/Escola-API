using System.Collections.Generic;
using Escola.Core.DominioBase;
using Escola.Domain.Enums;

namespace Escola.Domain.Entidades
{
    public class Escolaridade : EntidadeBase
    {
        public Escolaridade(EscolaridadeEnum escolaridadeTipo)
        {
            EscolaridadeTipo = escolaridadeTipo;
            _alunos = new List<Aluno>();
        }

        public EscolaridadeEnum EscolaridadeTipo { get; private set; }

        private readonly List<Aluno> _alunos;
        public IEnumerable<Aluno> Alunos => _alunos;
    }
}
