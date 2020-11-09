namespace EventosAPI.Domain.Modelos
{
    public class Palestrante
    {
        public int PalestranteId { get; set; }

        public string Nome { get; set; }

        public string ImagemUrl { get; set; }

        public int Telefone { get; set; }

        public string Minicurriculo { get; set; }

        public string Email { get; set; }
    }
}
