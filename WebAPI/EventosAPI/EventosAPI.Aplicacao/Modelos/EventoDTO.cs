using System;


namespace EventosAPI.Aplicacao.Modelos
{
    public class EventoDTO : BaseDTO
    {
        public string Endereco { get; set; }

        public DateTime DataEvento { get; set; }

        public string Tema { get; set; }

        public int QtdPessoas { get; set; }

        public string ImagemUrl { get; set; }

        public int Telefone { get; set; }
    }
}
