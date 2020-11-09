using AcessoFacilSqlServer;
using EventosAPI.Data.Context;
using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Modelos;
using Microsoft.Extensions.Configuration;

namespace EventosAPI.Data.Repositorio
{
    public class RepositorioConvidado : RepositorioBase<Convidado>, IRepositorioConvidado
    {
        #region Variáveis
        private readonly EventosContext _eventosContext;
        private readonly IConfiguration _configuration;
        private readonly string _stringConexao;
        #endregion

        #region Construtor
        public RepositorioConvidado(EventosContext eventosContext, IConfiguration configuration) : base(eventosContext)
        {
            _eventosContext = eventosContext;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region ObterPorNome
        public Convidado ObterPorNome(string nome)
        {
            using(Query query = new Query(_stringConexao))
            {
                query.Script = "select * from Convidado where NomeConvidado = @nome";
                query.AdicionarParametro("nome", nome);
                query.Abrir();

                while (query.Proximo())
                {
                    return new Convidado()
                    {
                        ConvidadoId = query.ObterInteiro("ConvidadoId"),
                        EventoId = query.ObterInteiro("EventoId"),
                        NomeConvidado = query.ObterString("NomeConvidado"),
                        EmailConvidado = query.ObterString("EmailConvidado"),
                        TelefoneConvidado = query.ObterInteiro("TelefoneConvidado"),
                        EnderecoConvidado = query.ObterString("EnderecoConvidado"),
                        LoteId = query.ObterInteiro("LoteId")
                    };
                }

                return null;
            }
        }
        #endregion
    }
}
