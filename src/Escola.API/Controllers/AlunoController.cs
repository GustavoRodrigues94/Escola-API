using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Escola.Application.Comandos;
using Escola.Application.Consultas;
using Escola.Application.Consultas.ViewModels;
using Escola.Application.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("v1/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoConsultas _alunoConsultas;

        public AlunoController(IAlunoConsultas alunoConsultas)
        {
            _alunoConsultas = alunoConsultas;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AdicionarAluno(
            [FromBody] AdicionarAlunoComando comando,
            [FromServices] AlunoComandoManipulador manipulador)
        {
            if (!comando.IsValid)
                return BadRequest(comando.Notifications);

            var resultado = await manipulador.Manipular(comando);

            return resultado.Sucesso ? (IActionResult) Ok(resultado) :  BadRequest(resultado);
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> AtualizarAluno(
            [FromBody] AtualizarAlunoComando comando,
            [FromServices] AlunoComandoManipulador manipulador)
        {
            if (!comando.IsValid)
                return BadRequest(comando.Notifications);

            var resultado = await manipulador.Manipular(comando);

            return resultado.Sucesso ? (IActionResult) Ok(resultado) : BadRequest(resultado);
        }

        [Route("{alunoId}")]
        [HttpDelete]
        public async Task<IActionResult> DeletarAluno(
            [FromServices] AlunoComandoManipulador manipulador, Guid alunoId)
        {
            var resultado = await manipulador.Manipular(new DeletarAlunoComando(alunoId));

            return resultado.Sucesso ? (IActionResult) Ok(resultado) : BadRequest(resultado);
        }

        [Route("{alunoId}")]
        [HttpGet]
        public async Task<AlunoViewModel> ObterAlunoPorId(Guid alunoId) =>
            await _alunoConsultas.ObterAlunoPorId(alunoId);

        [Route("todos")]
        [HttpGet]
        public async Task<IEnumerable<AlunoViewModel>> ObterAlunos() =>
            await _alunoConsultas.ObterAlunos();
    }
}
