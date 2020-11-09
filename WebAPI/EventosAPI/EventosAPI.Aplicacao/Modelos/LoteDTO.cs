using EventosAPI.Domain.Modelos;
using System;

namespace EventosAPI.Aplicacao.Modelos
{
    public class LoteDTO : BaseDTO
    {
        public int EventoId { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Quantidade { get; set; }
    }
}
