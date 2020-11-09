using EventosAPI.Domain.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Domain.Core.Interfaces.Servicos
{
    public interface IRedeSocialAPIServico : IAPIServicoBase<RedeSocial>
    {
        IEnumerable<RedeSocial> ObterPorGrupoId(int id);
    }
}
