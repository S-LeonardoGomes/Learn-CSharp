using AutoMapper;
using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Aplicacao.Servicos
{
    public class ServicoAplicacaoRedeSocial : IServicoAplicacaoRedeSocial
    {
        #region Variáveis
        private readonly IRedeSocialAPIServico _servicoRedeSocial;
        private readonly IMapper _mapper;
        #endregion

        #region Construtor
        public ServicoAplicacaoRedeSocial(IRedeSocialAPIServico servicoRedeSocial, IMapper mapper)
        {
            _servicoRedeSocial = servicoRedeSocial;
            _mapper = mapper;
        }
        #endregion

        #region Adicionar
        public void Adicionar(RedeSocialDTO obj)
        {
            var objEntity = _mapper.Map<RedeSocial>(obj);
            _servicoRedeSocial.Adicionar(objEntity);
        }
        #endregion

        #region Alterar
        public void Alterar(RedeSocialDTO obj)
        {
            var objEntity = _mapper.Map<RedeSocial>(obj);
            _servicoRedeSocial.Alterar(objEntity);
        }
        #endregion

        #region Deletar
        public void Deletar(RedeSocialDTO obj)
        {
            var objEntity = _mapper.Map<RedeSocial>(obj);
            _servicoRedeSocial.Deletar(objEntity);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _servicoRedeSocial.Dispose();
        }
        #endregion

        #region ObterPorId
        public RedeSocialDTO ObterPorId(int id)
        {
            var objEntity = _servicoRedeSocial.ObterPorId(id);
            return _mapper.Map<RedeSocialDTO>(objEntity);
        }
        #endregion

        #region ObterPorGrupoId
        public IEnumerable<RedeSocialDTO> ObterPorGrupoId(int id)
        {
            var objEntity = _servicoRedeSocial.ObterPorGrupoId(id);
            return _mapper.Map<IEnumerable<RedeSocialDTO>>(objEntity);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<RedeSocialDTO> ObterTodos()
        {
            var listObjEntity = _servicoRedeSocial.ObterTodos();
            return _mapper.Map<IEnumerable<RedeSocialDTO>>(listObjEntity);
        }
        #endregion
    }
}
