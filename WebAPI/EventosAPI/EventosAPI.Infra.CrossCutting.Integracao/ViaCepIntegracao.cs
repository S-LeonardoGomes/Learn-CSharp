using RestSharp;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventosAPI.Infra.CrossCutting.Integracao
{
    public class ViaCepIntegracao : IDisposable
    {
        public ResponseViaCep BuscarEndereco(string cep) 
        {
            var client = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonSerializer.Deserialize<ResponseViaCep>(response.Content);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
