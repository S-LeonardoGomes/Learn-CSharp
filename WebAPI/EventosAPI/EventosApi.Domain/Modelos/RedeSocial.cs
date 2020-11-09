namespace EventosAPI.Domain.Modelos
{
    public class RedeSocial
    {
        public int RedeSocialId { get; set; }

        public int? EventoId { get; set; }

        public int? PalestranteId { get; set; }

        public string Nome { get; set; }

        public string Url { get; set; }
    }
}
