using System;

namespace EventosAPI.Domain.Modelos
{
    public class Lote
    {
        public int LoteId { get; set; }

        public int EventoId { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Quantidade { get; set; }
    }
}
