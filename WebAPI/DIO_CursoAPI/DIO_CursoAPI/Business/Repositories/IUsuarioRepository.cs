using DIO_CursoAPI.Business.Entities;

namespace DIO_CursoAPI.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
    }
}
