namespace EventosAPI.Domain.Modelos
{
    public class Convidado
    {
        public int ConvidadoId { get; set; }

        public int EventoId { get; set; }

        public int LoteId { get; set; }

        public string NomeConvidado { get; set; }

        public string EmailConvidado { get; set; }

        public int TelefoneConvidado { get; set; }

        public string EnderecoConvidado { get; set; }
    }
}
