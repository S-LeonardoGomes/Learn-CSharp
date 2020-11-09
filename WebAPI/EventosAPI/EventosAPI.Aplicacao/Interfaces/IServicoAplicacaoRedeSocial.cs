using EventosAPI.Aplicacao.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoRedeSocial : IServicoAplicacaoBase<RedeSocialDTO>
    {
        IEnumerable<RedeSocialDTO> ObterPorGrupoId(int id);
    }
}
