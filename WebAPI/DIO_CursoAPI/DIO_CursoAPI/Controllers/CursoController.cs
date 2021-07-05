using DIO_CursoAPI.Business.Entities;
using DIO_CursoAPI.Business.Repositories;
using DIO_CursoAPI.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Security.Claims;

namespace DIO_CursoAPI.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar um curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost("")]
        public IActionResult Post(CursoViewModelInput cursoViewModelInput)
        {
            Curso curso = new Curso
            {
                Nome = cursoViewModelInput.Nome,
                Descricao = cursoViewModelInput.Descricao
            };

            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            curso.CodigoUsuario = codigoUsuario;

            _cursoRepository.Adicionar(curso);
            _cursoRepository.Commit();

            var cursoViewModelOutput = new CursoViewModelOutput
            {
                Nome = curso.Nome,
                Descricao = curso.Descricao
            };

            return Created("", cursoViewModelInput);
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet("")]
        public IActionResult Get()
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var cursos = _cursoRepository.ObterPorUsuario(codigoUsuario)
                .Select(s => new CursoViewModelOutput()
                {
                    Nome = s.Nome,
                    Descricao = s.Descricao,
                    Login = s.Usuario.Login
                });

            return Ok(cursos);
        }
    }
}
