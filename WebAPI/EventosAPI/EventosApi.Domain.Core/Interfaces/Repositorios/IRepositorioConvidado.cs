using EventosAPI.Domain.Modelos;

namespace EventosAPI.Domain.Core.Interfaces.Repositorios
{
    public interface IRepositorioConvidado : IRepositorioBase<Convidado>
    {
        Convidado ObterPorNome(string nome);
    }
}
