using DIO_CursoAPI.Business.Entities;
using DIO_CursoAPI.Business.Repositories;
using DIO_CursoAPI.Configuration;
using DIO_CursoAPI.Filters;
using DIO_CursoAPI.Models;
using DIO_CursoAPI.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DIO_CursoAPI.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthenticationService _authenticationService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
            _authenticationService = authenticationService;
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [ValidacaoModelStateCustomizado]
        [HttpPost("logar")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            //login provisório
            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "teste",
                Email = "teste@gmail.com"
            };

            var token = _authenticationService.GerarToken(usuarioViewModelOutput);

            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutput
            });
        }

        [ValidacaoModelStateCustomizado]
        [HttpPost("registrar")]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {
            /*
                        var migracoesPendentes = contexto.Database.GetPendingMigrations();
                        if (migracoesPendentes.Count() > 0)
                            contexto.Database.Migrate();
            */
            var usuario = new Usuario();
            usuario.Login = registroViewModelInput.Login;
            usuario.Senha = registroViewModelInput.Senha;
            usuario.Email = registroViewModelInput.Email;
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();

            return Created("", registroViewModelInput);
        }
    }
}
