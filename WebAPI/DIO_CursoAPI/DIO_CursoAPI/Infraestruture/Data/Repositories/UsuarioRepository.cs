using DIO_CursoAPI.Business.Entities;
using DIO_CursoAPI.Business.Repositories;
using System.Linq;

namespace DIO_CursoAPI.Infraestruture.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _contexto;

        public UsuarioRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public Usuario ObterUsuario(string login, string senha)
        {
            return _contexto.Usuario.FirstOrDefault(u => u.Login == login && u.Senha == senha);
        }
    }
}
