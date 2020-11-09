using System;
using System.Collections.Generic;
using System.Text;

namespace EventosAPI.Infra.CrossCutting.Integracao
{
    public class ResponseViaCep
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
    }
}
