using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Escola.Application.Comandos;
using Escola.Application.Consultas;
using Escola.Application.Consultas.ViewModels;
using Escola.Application.Manipuladores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        [AllowAnonymous]
        public async Task<IActionResult> AdicionarAluno(
            IFormFile historicoEscolar,
            [FromForm] string jsonAluno,
            [FromServices] AlunoComandoManipulador manipulador)
        {
            var comando = JsonConvert.DeserializeObject<AdicionarAlunoComando>(jsonAluno);
            comando.AdicionarHistoricoEscolarImagem(historicoEscolar);

            if (!comando.IsValid)
                return BadRequest(comando.Notifications);

            var resultado = await manipulador.Manipular(comando);

            return resultado.Sucesso ? Ok(resultado) as IActionResult  : BadRequest(resultado);
        }

        [Route("")]
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> AtualizarAluno(
            IFormFile historicoEscolar,
            [FromForm] string jsonAluno,
            [FromServices] AlunoComandoManipulador manipulador)
        {
            var comando = JsonConvert.DeserializeObject<AtualizarAlunoComando>(jsonAluno);
            comando.AdicionarHistoricoEscolarImagem(historicoEscolar);

            if (!comando.IsValid)
                return BadRequest(comando.Notifications);

            var resultado = await manipulador.Manipular(comando);

            return resultado.Sucesso ? Ok(resultado) as IActionResult : BadRequest(resultado);
        }

        [Route("{alunoId}")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> DeletarAluno(
            [FromServices] AlunoComandoManipulador manipulador, Guid alunoId)
        {
            var resultado = await manipulador.Manipular(new DeletarAlunoComando(alunoId));

            return resultado.Sucesso ? Ok(resultado) as IActionResult : BadRequest(resultado);
        }

        [Route("{alunoId}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<AlunoViewModel> ObterAlunoPorId(Guid alunoId) =>
            await _alunoConsultas.ObterAlunoPorId(alunoId);

        [Route("todos")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<AlunoViewModel>> ObterAlunos() =>
            await _alunoConsultas.ObterAlunos();

        [Route("escolaridade")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<EscolaridadeViewModel>> ObterListaEscolaridade() =>
            await _alunoConsultas.ObterListaEscolaridade();
    }
}
