using EventosAPI.Domain.Modelos;

namespace EventosAPI.Domain.Core.Interfaces.Servicos
{
    public interface IConvidadoAPIServico : IAPIServicoBase<Convidado>
    {
        Convidado ObterPorNome(string nome);
    }
}
