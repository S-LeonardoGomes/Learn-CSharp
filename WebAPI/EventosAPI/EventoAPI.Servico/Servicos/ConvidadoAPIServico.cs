using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Domain.Modelos;

namespace EventosAPI.Servico.Servicos
{
    public class ConvidadoAPIServico : ServicoBase<Convidado>, IConvidadoAPIServico
    {
        private readonly IRepositorioConvidado _repositorioConvidado;

        #region Construtor
        public ConvidadoAPIServico(IRepositorioConvidado repositorioConvidado) : base(repositorioConvidado)
        {
            _repositorioConvidado = repositorioConvidado;
        }
        #endregion

        #region ObterPorNome
        public Convidado ObterPorNome(string nome)
        {
            return _repositorioConvidado.ObterPorNome(nome);
        }
        #endregion
    }
}
