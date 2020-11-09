using EventosAPI.Domain.Modelos;

namespace EventosAPI.Aplicacao.Modelos
{
    public class PalestranteEventoDTO : BaseDTO
    {
        public int EventoId { get; set; }

        public int PalestranteId { get; set; }
    }
}
