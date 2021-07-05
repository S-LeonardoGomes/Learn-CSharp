namespace DIO_CursoAPI.Models.Usuarios
{
    public class LoginViewModelOutput
    {
        public string Token { get; set; }
        public UsuarioViewModelOutput Usuario { get; set; }
    }
}
