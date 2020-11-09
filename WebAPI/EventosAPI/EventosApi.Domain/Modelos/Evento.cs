using System;

namespace EventosAPI.Domain.Modelos
{
    public class Evento
    {
        public int EventoId { get; set; }

        public string Endereco { get; set; }

        public DateTime DataEvento { get; set; }

        public string Tema { get; set; }

        public int QtdPessoas { get; set; }

        public string ImagemUrl { get; set; }

        public int Telefone { get; set; }
    }
}
