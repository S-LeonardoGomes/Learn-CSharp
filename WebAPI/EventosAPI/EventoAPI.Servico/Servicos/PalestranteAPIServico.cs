using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;

namespace EventosAPI.Servico.Servicos
{
    public class PalestranteAPIServico : ServicoBase<Palestrante>, IPalestranteAPIServico
    {
        private readonly IRepositorioPalestrante _repositorioPalestrante;

        #region Construtor
        public PalestranteAPIServico(IRepositorioPalestrante repositorioPalestrante) : base(repositorioPalestrante)
        {
            _repositorioPalestrante = repositorioPalestrante;
        }
        #endregion
    }
}
