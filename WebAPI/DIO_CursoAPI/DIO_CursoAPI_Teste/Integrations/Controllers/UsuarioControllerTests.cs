using AutoBogus;
using DIO_CursoAPI;
using DIO_CursoAPI.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
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
using Xunit.Abstractions;

namespace DIO_CursoAPI_Teste.Integrations.Controllers
{
    public class UsuarioControllerTests : IClassFixture<WebApplicationFactory<Startup>>, IAsyncLifetime
    {
        private readonly WebApplicationFactory<Startup> _factory;
        protected readonly ITestOutputHelper _output;
        protected readonly HttpClient _httpClient;
        protected RegistroViewModelInput RegistroViewModelInput;
        protected LoginViewModelOutput LoginViewModelOutput;

        public UsuarioControllerTests(WebApplicationFactory<Startup> factory,
            ITestOutputHelper output)
        {
            _factory = factory;
            _output = output;
            //autenticar//trafegar nas rotas
            _httpClient = _factory.CreateClient();
        }

        public async Task DisposeAsync()
        {
            _httpClient.Dispose();

        }

        public async Task InitializeAsync()
        {
            await Registrar_InformandoUsuarioESenha_DeveRetornarSucesso();
            await Logar_InformandoUsuarioESenhaExistentes_DeveRetornarSucesso();
        }

        [Fact]
        public async Task Logar_InformandoUsuarioESenhaExistentes_DeveRetornarSucesso()
        {
            //Arrange
            var loginViewModelInput = new LoginViewModelInput
            {
                Login = RegistroViewModelInput.Login,
                Senha = RegistroViewModelInput.Senha
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginViewModelInput),
                Encoding.UTF8, "application/json");

            //Act
            var httpClientRequest = await _httpClient.PostAsync("api/v1/usuario/logar", content);

            LoginViewModelOutput = JsonConvert.DeserializeObject<LoginViewModelOutput>
                (await httpClientRequest.Content.ReadAsStringAsync());

            //Assert
            Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
            Assert.NotNull(LoginViewModelOutput.Token);
            Assert.Equal(loginViewModelInput.Login, LoginViewModelOutput.Usuario.Login);
            _output.WriteLine($"{nameof(CursoControllerTests)} : " +
                $"{nameof(Logar_InformandoUsuarioESenhaExistentes_DeveRetornarSucesso)} -> " +
                $"{LoginViewModelOutput.Token}");
        }

        [Fact]
        public async Task Registrar_InformandoUsuarioESenha_DeveRetornarSucesso()
        {
            //Arrange
            RegistroViewModelInput = new AutoFaker<RegistroViewModelInput>()
                .RuleFor(p => p.Email, faker => faker.Person.Email);

            StringContent content = new StringContent(JsonConvert.SerializeObject(RegistroViewModelInput),
                Encoding.UTF8, "application/json");

            //Act
            var httpClientRequest = await _httpClient.PostAsync("api/v1/usuario/registrar", content);

            //Assert
            _output.WriteLine($"{nameof(UsuarioControllerTests)} : " +
                $"{nameof(Registrar_InformandoUsuarioESenha_DeveRetornarSucesso)} -> " +
                $"{await httpClientRequest.Content.ReadAsStringAsync()}");
            Assert.Equal(HttpStatusCode.Created, httpClientRequest.StatusCode);
        }
    }
}
