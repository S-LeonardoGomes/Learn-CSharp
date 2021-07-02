using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO_CursoAPI.Models.Usuarios
{
    public class LoginViewModelInput
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
