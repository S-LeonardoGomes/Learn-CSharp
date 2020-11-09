using AutoMapper;
using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Aplicacao.Servicos
{
    public class ServicoAplicacaoLote : IServicoAplicacaoLote
    {
        #region Variáveis
        private readonly ILoteAPIServico _servicoLote;
        private readonly IMapper _mapper;
        #endregion

        #region Construtor
        public ServicoAplicacaoLote(ILoteAPIServico servicoLote, IMapper mapper)
        {
            _servicoLote = servicoLote;
            _mapper = mapper;
        }
        #endregion

        #region Adicionar
        public void Adicionar(LoteDTO obj)
        {
            var objEntity = _mapper.Map<Lote>(obj);
            _servicoLote.Adicionar(objEntity);
        }
        #endregion

        #region Alterar
        public void Alterar(LoteDTO obj)
        {
            var objEntity = _mapper.Map<Lote>(obj);
            _servicoLote.Alterar(objEntity);
        }
        #endregion

        #region Deletar
        public void Deletar(LoteDTO obj)
        {
            var objEntity = _mapper.Map<Lote>(obj);
            _servicoLote.Deletar(objEntity);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _servicoLote.Dispose();
        }
        #endregion

        #region ObterPorId
        public LoteDTO ObterPorId(int id)
        {
            var objEntity = _servicoLote.ObterPorId(id);
            return _mapper.Map<LoteDTO>(objEntity);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<LoteDTO> ObterTodos()
        {
            var listObjEntity = _servicoLote.ObterTodos();
            return _mapper.Map<IEnumerable<LoteDTO>>(listObjEntity);
        }
        #endregion
    }
}
