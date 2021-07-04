using DIO_CursoAPI;
using DIO_CursoAPI.Models.Usuarios;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DIO_CursoAPI_Teste.Integrations.Controllers
{
    public class UsuarioControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _httpClient;

        public UsuarioControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            //autenticar//trafegar nas rotas
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public void Logar_InformandoUsuarioESenhaExistentes_DeveRetornarSucesso()
        {
            //Arrange
            var loginViewModelInput = new LoginViewModelInput
            {
                Login = "string",
                Senha = "string"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginViewModelInput),
                Encoding.UTF8, "application/json");

            //Act
            var httpClientRequest = _httpClient.PostAsync("api/v1/usuario/logar", content)
                .GetAwaiter().GetResult();

            //Assert
            Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
        }

        [Fact]
        public void Registrar_InformandoUsuarioESenha_DeveRetornarSucesso()
        {
            //Arrange
            var registroViewModelInput = new RegistroViewModelInput
            {
                Login = "Teste",
                Email = "teste@teste.com",
                Senha = "abc1234"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(registroViewModelInput),
                Encoding.UTF8, "application/json");

            //Act
            var httpClientRequest = _httpClient.PostAsync("api/v1/usuario/registrar", content)
                .GetAwaiter().GetResult();

            //Assert
            Assert.Equal(HttpStatusCode.Created, httpClientRequest.StatusCode);
        }
    }
}
