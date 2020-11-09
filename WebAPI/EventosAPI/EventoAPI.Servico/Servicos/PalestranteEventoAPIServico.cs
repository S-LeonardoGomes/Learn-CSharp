using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;

namespace EventosAPI.Servico.Servicos
{
    public class PalestranteEventoAPIServico : ServicoBase<PalestranteEvento>, IPalestranteEventoAPIServico
    {
        private readonly IRepositorioPalestranteEvento _repositorioPalestranteEvento;

        #region Construtor
        public PalestranteEventoAPIServico(IRepositorioPalestranteEvento repositorioPalestranteEvento) : base(repositorioPalestranteEvento)
        {
            _repositorioPalestranteEvento = repositorioPalestranteEvento;
        }
        #endregion
    }
}
