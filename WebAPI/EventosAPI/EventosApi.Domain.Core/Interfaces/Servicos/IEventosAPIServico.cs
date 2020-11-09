using EventosAPI.Domain.Modelos;
using System;
using EventosAPI.Infra.CrossCutting.Integracao;

namespace EventosAPI.Domain.Core.Interfaces.Servicos
{
    public interface IEventosAPIServico : IAPIServicoBase<Evento>
    {
        Evento ObterEventoPorTema(string tema);
        Evento ObterEventoPorData(DateTime? data);
        ResponseViaCep ObterEnderecoPorCep(string cep);
    }
}
