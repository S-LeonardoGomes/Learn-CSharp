using EventosAPI.Domain.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Domain.Core.Interfaces.Repositorios
{
    public interface IRepositorioRedeSocial : IRepositorioBase<RedeSocial>
    {
        IEnumerable<RedeSocial> ObterPorGrupoId(int id);
    }
}
