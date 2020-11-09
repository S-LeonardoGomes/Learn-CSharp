using EventosAPI.Domain.Modelos;
using System;

namespace EventosAPI.Domain.Core.Interfaces.Repositorios
{
    public interface IRepositorioEvento : IRepositorioBase<Evento>
    {
        Evento ObterEventoPorTema(string tema);
        Evento ObterEventoPorData(DateTime? data);
    }
}
