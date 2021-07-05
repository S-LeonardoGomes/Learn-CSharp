using AutoBogus;
using DIO_CursoAPI;
using DIO_CursoAPI.Models.Cursos;
using DIO_CursoAPI.Models.Usuarios;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task Registrar_InformandoDadosDeUmCursoValido_DeveRetornarSucesso()
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
                $"{nameof(Registrar_InformandoDadosDeUmCursoValido_DeveRetornarSucesso)} -> " +
                $"{await httpClientRequest.Content.ReadAsStringAsync()}");
            Assert.Equal(HttpStatusCode.Created, httpClientRequest.StatusCode);
        }
    }
}
