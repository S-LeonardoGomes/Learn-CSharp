using AutoBogus;
using DIO_CursoAPI;
using DIO_CursoAPI.Models.Cursos;
using DIO_CursoAPI.Models.Usuarios;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DIO_CursoAPI_Teste.Integrations.Controllers
{
    public class CursoControllerTests : UsuarioControllerTests
    {
        public CursoControllerTests(WebApplicationFactory<Startup> factory,
            ITestOutputHelper output) : base(factory, output)
        {
        }

        [Fact]
        public async Task Registrar_InformandoDadosDeUmCursoValidoEUmUsuarioAutenticado_DeveRetornarSucesso()
        {
            //Arrange
            var cursoViewModelInput = new AutoFaker<CursoViewModelInput>();

            StringContent content = new StringContent(JsonConvert.SerializeObject(cursoViewModelInput.Generate()),
                Encoding.UTF8, "application/json");

            //Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                LoginViewModelOutput.Token);
            var httpClientRequest = await _httpClient.PostAsync("api/v1/cursos", content);

            //Assert
            _output.WriteLine($"{nameof(CursoControllerTests)} : " +
                $"{nameof(Registrar_InformandoDadosDeUmCursoValidoEUmUsuarioAutenticado_DeveRetornarSucesso)} -> " +
                $"{await httpClientRequest.Content.ReadAsStringAsync()}");
            Assert.Equal(HttpStatusCode.Created, httpClientRequest.StatusCode);
        }

        [Fact]
        public async Task Registrar_InformandoDadosDeUmCursoValidoEUmUsuarioNaoAutenticado_DeveRetornarSucesso()
        {
            //Arrange
            var cursoViewModelInput = new AutoFaker<CursoViewModelInput>();

            StringContent content = new StringContent(JsonConvert.SerializeObject(cursoViewModelInput.Generate()),
                Encoding.UTF8, "application/json");

            //Act
            var httpClientRequest = await _httpClient.PostAsync("api/v1/cursos", content);

            //Assert
            _output.WriteLine($"{nameof(CursoControllerTests)} : " +
                $"{nameof(Registrar_InformandoDadosDeUmCursoValidoEUmUsuarioAutenticado_DeveRetornarSucesso)} -> " +
                $"{await httpClientRequest.Content.ReadAsStringAsync()}");
            Assert.Equal(HttpStatusCode.Unauthorized, httpClientRequest.StatusCode);
        }

        [Fact]
        public async Task Obter_InformandoUmUsuarioAutenticado_DeveRetornarSucesso()
        {
            //Arrange
            await Registrar_InformandoDadosDeUmCursoValidoEUmUsuarioAutenticado_DeveRetornarSucesso();

            //Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                LoginViewModelOutput.Token);
            var httpClientRequest = await _httpClient.GetAsync("api/v1/cursos");

            //Assert
            _output.WriteLine($"{nameof(CursoControllerTests)} : " +
                $"{nameof(Obter_InformandoUmUsuarioAutenticado_DeveRetornarSucesso)} -> " +
                $"{await httpClientRequest.Content.ReadAsStringAsync()}");

            var cursos = JsonConvert.DeserializeObject<IList<CursoViewModelOutput>>
                (await httpClientRequest.Content.ReadAsStringAsync());

            Assert.NotEmpty(cursos);
            Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
        }
    }
}
