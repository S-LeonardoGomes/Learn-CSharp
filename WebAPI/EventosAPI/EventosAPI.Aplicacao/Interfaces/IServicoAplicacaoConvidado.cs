using EventosAPI.Aplicacao.Modelos;
using System.Collections.Generic;

namespace EventosAPI.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoConvidado : IServicoAplicacaoBase<ConvidadoDTO>
    {
        ConvidadoDTO ObterPorNome(string nome);
    }
}
