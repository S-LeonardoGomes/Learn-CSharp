using AutoMapper;
using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;
using System;
using System.Collections.Generic;

namespace EventosAPI.Aplicacao.Servicos
{
    public class ServicoAplicacaoEvento : IServicoAplicacaoEvento
    {
        #region Variáveis
        private readonly IEventosAPIServico _servicoEvento;
        private readonly IMapper _mapper;
        #endregion

        #region Construtor
        public ServicoAplicacaoEvento(IEventosAPIServico servicoEvento, IMapper mapper)
        {
            _servicoEvento = servicoEvento;
            _mapper = mapper;
        }
        #endregion

        #region Adicionar
        public void Adicionar(EventoDTO obj)
        {
            var objEntity = _mapper.Map<Evento>(obj);  
            _servicoEvento.Adicionar(objEntity);            
        }
        #endregion

        #region Alterar
        public void Alterar(EventoDTO obj)
        {
            var objEntity = _mapper.Map<Evento>(obj);
            _servicoEvento.Alterar(objEntity);
        }
        #endregion

        #region Deletar
        public void Deletar(EventoDTO obj)
        {
            var objEntity = _mapper.Map<Evento>(obj);
            _servicoEvento.Deletar(objEntity);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _servicoEvento.Dispose();
        }
        #endregion

        #region ObterPorId
        public EventoDTO ObterPorId(int id)
        {
            var objEntity = _servicoEvento.ObterPorId(id);
            return _mapper.Map<EventoDTO>(objEntity);
        }
        #endregion

        #region ObterPorTema
        public EventoDTO ObterPorTema(string tema)
        {
            Evento objEntity;
            EventoDTO objMapper;

            try
            {
                objEntity = _servicoEvento.ObterEventoPorTema(tema);
                objMapper = _mapper.Map<EventoDTO>(objEntity);

                objMapper.Codigo = 0;
                objMapper.Mensagem = "Sucesso.";
            }
            catch(NullReferenceException)
            {
                objMapper = new EventoDTO();
                objMapper.Codigo = 2;
                objMapper.Mensagem = $"Não foi encontrado nenhum registro.";
            }
            catch (Exception ex)
            {
                objMapper = new EventoDTO();
                objMapper.Codigo = 1;
                objMapper.Mensagem = $"Ocorreu um erro ao requisitar. Erro: {ex.Message}";
            }

            return objMapper;
        }
        #endregion

        #region ObterPorData
        public EventoDTO ObterPorData(DateTime? data)
        {
            Evento objEntity;
            EventoDTO objMapper;

            try
            {
                objEntity = _servicoEvento.ObterEventoPorData(data);
                objMapper = _mapper.Map<EventoDTO>(objEntity);

                objMapper.Codigo = 0;
                objMapper.Mensagem = "Sucesso.";
            }
            catch (NullReferenceException)
            {
                objMapper = new EventoDTO();
                objMapper.Codigo = 2;
                objMapper.Mensagem = $"Não foi encontrado nenhum registro.";
            }
            catch (Exception ex)
            {
                objMapper = new EventoDTO();
                objMapper.Codigo = 1;
                objMapper.Mensagem = $"Ocorreu um erro ao requisitar. Erro: {ex.Message}";
            }

            return objMapper;
        }
        #endregion

        #region ObterEnderecoPorCep
        public ResponseViaCepDTO ObterEnderecoPorCep(string cep)
        {
            var objEntity = _servicoEvento.ObterEnderecoPorCep(cep);
            return _mapper.Map<ResponseViaCepDTO>(objEntity);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<EventoDTO> ObterTodos()
        {
            var listObjEntity = _servicoEvento.ObterTodos();
            return _mapper.Map<IEnumerable<EventoDTO>>(listObjEntity);
        }
        #endregion
    }
}
