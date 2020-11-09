using AutoMapper;
using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Aplicacao.Servicos
{
    public class ServicoAplicacaoPalestrante : IServicoAplicacaoPalestrante
    {
        #region Variáveis
        private readonly IPalestranteAPIServico _servicoPalestrante;
        private readonly IMapper _mapper;
        #endregion

        #region Construtor
        public ServicoAplicacaoPalestrante(IPalestranteAPIServico servicoPalestrante, IMapper mapper)
        {
            _servicoPalestrante = servicoPalestrante;
            _mapper = mapper;
        }
        #endregion

        #region Adicionar
        public void Adicionar(PalestranteDTO obj)
        {
            var objEntity = _mapper.Map<Palestrante>(obj);
            _servicoPalestrante.Adicionar(objEntity);
        }
        #endregion

        #region Alterar
        public void Alterar(PalestranteDTO obj)
        {
            var objEntity = _mapper.Map<Palestrante>(obj);
            _servicoPalestrante.Alterar(objEntity);
        }
        #endregion

        #region Deletar
        public void Deletar(PalestranteDTO obj)
        {
            var objEntity = _mapper.Map<Palestrante>(obj);
            _servicoPalestrante.Deletar(objEntity);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _servicoPalestrante.Dispose();
        }
        #endregion

        #region ObterPorId
        public PalestranteDTO ObterPorId(int id)
        {
            var objEntity = _servicoPalestrante.ObterPorId(id);
            return _mapper.Map<PalestranteDTO>(objEntity);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<PalestranteDTO> ObterTodos()
        {
            var listObjEntity = _servicoPalestrante.ObterTodos();
            return _mapper.Map<IEnumerable<PalestranteDTO>>(listObjEntity);
        }
        #endregion
    }
}
