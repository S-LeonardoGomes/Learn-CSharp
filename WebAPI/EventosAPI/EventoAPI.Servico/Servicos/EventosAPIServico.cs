using EventosAPI.Aplicacao.Modelos;
using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;
using EventosAPI.Infra.CrossCutting.Integracao;
using System;

namespace EventosAPI.Servico.Servicos
{
    public class EventosAPIServico : ServicoBase<Evento>, IEventosAPIServico
    {
        private readonly IRepositorioEvento _repositorioEvento;

        #region Construtor
        public EventosAPIServico(IRepositorioEvento repositorioEvento) : base(repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }
        #endregion

        #region ObterEventoPorTema
        public Evento ObterEventoPorTema(string tema)
        {
            return _repositorioEvento.ObterEventoPorTema(tema);
        }
        #endregion

        #region ObterEventoPorData
        public Evento ObterEventoPorData(DateTime? data)
        {
            return _repositorioEvento.ObterEventoPorData(data);
        }
        #endregion

        #region ObterEnderecoPorCep
        public ResponseViaCep ObterEnderecoPorCep(string cep)
        {
            using (ViaCepIntegracao integracao = new ViaCepIntegracao())
            {
               return integracao.BuscarEndereco(cep);
            }
        }
        #endregion
    }
}
