using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Servico.Servicos
{
    public class RedeSocialAPIServico : ServicoBase<RedeSocial>, IRedeSocialAPIServico
    {
        private readonly IRepositorioRedeSocial _repositorioRedeSocial;

        #region Construtor
        public RedeSocialAPIServico(IRepositorioRedeSocial repositorioRedeSocial) : base(repositorioRedeSocial)
        {
            _repositorioRedeSocial = repositorioRedeSocial;
        }
        #endregion

        #region ObterPorGrupoId
        public IEnumerable<RedeSocial> ObterPorGrupoId(int id)
        {
            return _repositorioRedeSocial.ObterPorGrupoId(id);
        }
        #endregion
    }
}
