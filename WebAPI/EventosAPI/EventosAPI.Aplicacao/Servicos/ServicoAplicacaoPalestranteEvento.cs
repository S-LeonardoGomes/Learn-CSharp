using AutoMapper;
using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Aplicacao.Servicos
{
    public class ServicoAplicacaoPalestranteEvento : IServicoAplicacaoPalestranteEvento
    {
        #region Variáveis
        private readonly IPalestranteEventoAPIServico _servicoPalestranteEvento;
        private readonly IMapper _mapper;
        #endregion

        #region Construtor
        public ServicoAplicacaoPalestranteEvento(IPalestranteEventoAPIServico servicoPalestranteEvento, IMapper mapper)
        {
            _servicoPalestranteEvento = servicoPalestranteEvento;
            _mapper = mapper;
        }
        #endregion

        #region Adicionar
        public void Adicionar(PalestranteEventoDTO obj)
        {
            var objEntity = _mapper.Map<PalestranteEvento>(obj);
            _servicoPalestranteEvento.Adicionar(objEntity);
        }
        #endregion

        #region Alterar
        public void Alterar(PalestranteEventoDTO obj)
        {
            var objEntity = _mapper.Map<PalestranteEvento>(obj);
            _servicoPalestranteEvento.Alterar(objEntity);
        }
        #endregion

        #region Deletar
        public void Deletar(PalestranteEventoDTO obj)
        {
            var objEntity = _mapper.Map<PalestranteEvento>(obj);
            _servicoPalestranteEvento.Deletar(objEntity);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _servicoPalestranteEvento.Dispose();
        }
        #endregion

        #region ObterPorId
        public PalestranteEventoDTO ObterPorId(int id)
        {
            var objEntity = _servicoPalestranteEvento.ObterPorId(id);
            return _mapper.Map<PalestranteEventoDTO>(objEntity);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<PalestranteEventoDTO> ObterTodos()
        {
            var listObjEntity = _servicoPalestranteEvento.ObterTodos();
            return _mapper.Map<IEnumerable<PalestranteEventoDTO>>(listObjEntity);
        }
        #endregion
    }
}
