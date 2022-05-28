using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Escola.Application.Consultas.ViewModels;
using Escola.Core.Utilitarios;
using Escola.Domain.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Escola.Application.Consultas
{
    public class AlunoConsultas : IAlunoConsultas
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoConsultas(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task<AlunoViewModel> ObterAlunoPorId(Guid alunoId)
        {
            var aluno = await _alunoRepositorio.ObterAlunoPorId(alunoId);
            if (aluno is null) return null;

            var alunoViewModel = new AlunoViewModel
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Sobrenome = aluno.Sobrenome,
                DataNascimento = aluno.DataNascimento,
                Email = aluno.Email,
                HistoricoEscolar = new HistoricoEscolarViewModel
                {
                    Id = aluno.HistoricoEscolar.Id,
                    Nome = aluno.HistoricoEscolar.Nome,
                    FormatoHistoricoEnum = aluno.HistoricoEscolar.Formato,
                    FormatoHistoricoDescricao = aluno.HistoricoEscolar.Formato.ObterDescricaoEnum(),
                    HistoricoBase64 = aluno.HistoricoEscolar.HistoricoBase64
                },
                Escolaridade = new EscolaridadeViewModel
                {
                    Id = aluno.Escolaridade.Id,
                    EscolaridadeEnum = aluno.Escolaridade.EscolaridadeTipo,
                    EscolaridadeDescricao = aluno.Escolaridade.EscolaridadeTipo.ObterDescricaoEnum()
                }
            };

            return alunoViewModel;
        }

        public async Task<IEnumerable<AlunoViewModel>> ObterAlunos() => await _alunoRepositorio.ObterAlunos().Select(
            aluno => new AlunoViewModel
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Sobrenome = aluno.Sobrenome,
                DataNascimento = aluno.DataNascimento,
                Email = aluno.Email,
                HistoricoEscolar = new HistoricoEscolarViewModel
                {
                    Id = aluno.HistoricoEscolar.Id,
                    Nome = aluno.HistoricoEscolar.Nome,
                    FormatoHistoricoEnum = aluno.HistoricoEscolar.Formato,
                    FormatoHistoricoDescricao = aluno.HistoricoEscolar.Formato.ObterDescricaoEnum(),
                    HistoricoBase64 = aluno.HistoricoEscolar.HistoricoBase64
                },
                Escolaridade = new EscolaridadeViewModel
                {
                    Id = aluno.Escolaridade.Id,
                    EscolaridadeEnum = aluno.Escolaridade.EscolaridadeTipo,
                    EscolaridadeDescricao = aluno.Escolaridade.EscolaridadeTipo.ObterDescricaoEnum()
                }
            }).ToListAsync();
    }
}
