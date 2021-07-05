﻿using DIO_CursoAPI.Business.Entities;
using DIO_CursoAPI.Business.Repositories;
using DIO_CursoAPI.Configuration;
using DIO_CursoAPI.Filters;
using DIO_CursoAPI.Models;
using DIO_CursoAPI.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Logar(LoginViewModelInput loginViewModelInput)
        {
            var usuario = await _usuarioRepository.ObterUsuarioAsync(loginViewModelInput.Login, loginViewModelInput.Senha);

            if (usuario == null)
                return BadRequest("Houve um erro ao tentar acessar.");
            /*
            if (usuario.Senha != loginViewModel.Senha.GerarSenhaCriptogafada())
                return BadRequest("Houve um erro ");
            */
            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = usuario.Codigo,
                Login = loginViewModelInput.Login,
                Email = usuario.Email
            };

            var token = _authenticationService.GerarToken(usuarioViewModelOutput);

            return Ok(new LoginViewModelOutput
            {
                Token = token,
                Usuario = usuarioViewModelOutput
            });
        }

        [ValidacaoModelStateCustomizado]
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RegistroViewModelInput registroViewModelInput)
        {
            /*
                        var migracoesPendentes = contexto.Database.GetPendingMigrations();
                        if (migracoesPendentes.Count() > 0)
                            contexto.Database.Migrate();
            */

            var usuario = await _usuarioRepository.ObterUsuarioAsync(registroViewModelInput.Login,
                registroViewModelInput.Senha);

            if (usuario != null)
                return BadRequest("Usuário já cadastrado");

            usuario = new Usuario();
            usuario.Login = registroViewModelInput.Login;
            usuario.Senha = registroViewModelInput.Senha;
            usuario.Email = registroViewModelInput.Email;
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();

            return Created("", registroViewModelInput);
        }
    }
}
