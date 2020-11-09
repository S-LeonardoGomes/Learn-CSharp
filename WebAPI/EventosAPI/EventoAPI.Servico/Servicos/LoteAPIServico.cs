using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;

namespace EventosAPI.Servico.Servicos
{
    public class LoteAPIServico : ServicoBase<Lote>, ILoteAPIServico
    {
        private readonly IRepositorioLote _repositorioLote;

        #region Construtor
        public LoteAPIServico(IRepositorioLote repositorioLote) : base(repositorioLote)
        {
            _repositorioLote = repositorioLote;
        }
        #endregion
    }
}
