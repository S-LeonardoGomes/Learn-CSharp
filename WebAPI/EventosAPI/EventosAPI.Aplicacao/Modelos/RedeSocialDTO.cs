using EventosAPI.Domain.Modelos;

namespace EventosAPI.Aplicacao.Modelos
{
    public class RedeSocialDTO : BaseDTO
    {
        public int? EventoId { get; set; }

        public int? PalestranteId { get; set; }

        public string Nome { get; set; }

        public string Url { get; set; }
    }
}
