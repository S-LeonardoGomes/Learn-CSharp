using EventosAPI.Aplicacao.Modelos;
using EventosAPI.Domain.Modelos;
using System;

namespace EventosAPI.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoEvento : IServicoAplicacaoBase<EventoDTO>
    {
        EventoDTO ObterPorTema(string tema);
        EventoDTO ObterPorData(DateTime? data);
        ResponseViaCepDTO ObterEnderecoPorCep(string cep);
    }
}
