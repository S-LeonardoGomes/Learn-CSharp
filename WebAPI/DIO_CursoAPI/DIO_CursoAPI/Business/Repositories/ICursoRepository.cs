using DIO_CursoAPI.Business.Entities;
using System.Collections.Generic;

namespace DIO_CursoAPI.Business.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        void Commit();
        IList<Curso> ObterPorUsuario(int codigoUsuario);
    }
}
