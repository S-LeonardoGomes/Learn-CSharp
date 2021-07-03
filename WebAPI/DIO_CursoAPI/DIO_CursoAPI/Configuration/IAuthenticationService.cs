using DIO_CursoAPI.Models.Usuarios;

namespace DIO_CursoAPI.Configuration
{
    public interface IAuthenticationService
    {
        string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}
