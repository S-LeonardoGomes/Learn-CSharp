using DIO_CursoAPI.Business.Entities;
using System.Threading.Tasks;

namespace DIO_CursoAPI.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
        Task<Usuario> ObterUsuarioAsync(string login, string senha);
    }
}
