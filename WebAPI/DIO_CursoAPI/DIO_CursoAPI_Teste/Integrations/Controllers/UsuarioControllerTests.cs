using DIO_CursoAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_CursoAPI_Teste.Integrations.Controllers
{
    public class UsuarioControllerTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UsuarioControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
    }
}
