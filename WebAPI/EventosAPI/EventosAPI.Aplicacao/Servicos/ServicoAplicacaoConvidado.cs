using AutoMapper;
using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Aplicacao.Servicos
{
    public class ServicoAplicacaoConvidado : IServicoAplicacaoConvidado
    {
        #region Variáveis
        private readonly IConvidadoAPIServico _servicoConvidado;
        private readonly IMapper _mapper;
        #endregion

        #region Construtor
        public ServicoAplicacaoConvidado(IConvidadoAPIServico servicoConvidado, IMapper mapper)
        {
            _servicoConvidado = servicoConvidado;
            _mapper = mapper;
        }
        #endregion

        #region Adicionar
        public void Adicionar(ConvidadoDTO obj)
        {
            var objEntity = _mapper.Map<Convidado>(obj);
            _servicoConvidado.Adicionar(objEntity);
        }
        #endregion

        #region Alterar
        public void Alterar(ConvidadoDTO obj)
        {
            var objEntity = _mapper.Map<Convidado>(obj);
            _servicoConvidado.Alterar(objEntity);
        }
        #endregion

        #region Deletar
        public void Deletar(ConvidadoDTO obj)
        {
            var objEntity = _mapper.Map<Convidado>(obj);
            _servicoConvidado.Deletar(objEntity);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _servicoConvidado.Dispose();
        }
        #endregion

        #region ObterPorId
        public ConvidadoDTO ObterPorId(int id)
        {
            var objEntity = _servicoConvidado.ObterPorId(id);
            return _mapper.Map<ConvidadoDTO>(objEntity);
        }
        #endregion

        #region ObterPorNome
        public ConvidadoDTO ObterPorNome(string nome)
        {
            var objEntity = _servicoConvidado.ObterPorNome(nome);
            return _mapper.Map<ConvidadoDTO>(objEntity);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<ConvidadoDTO> ObterTodos()
        {
            var listObjEntity = _servicoConvidado.ObterTodos();
            return _mapper.Map<IEnumerable<ConvidadoDTO>>(listObjEntity);
        }
        #endregion
    }
}
