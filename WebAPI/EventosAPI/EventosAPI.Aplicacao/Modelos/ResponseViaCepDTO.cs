using System;
using System.Collections.Generic;
using System.Text;

namespace EventosAPI.Aplicacao.Modelos
{
    public class ResponseViaCepDTO
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string uf { get; set; }
    }
}
