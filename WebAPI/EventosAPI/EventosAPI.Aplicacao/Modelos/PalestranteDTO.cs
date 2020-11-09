namespace EventosAPI.Aplicacao.Modelos
{
    public class PalestranteDTO : BaseDTO
    {
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }
        public int Telefone { get; set; }
        public string Minicurriculo { get; set; }
        public string Email { get; set; }
    }
}