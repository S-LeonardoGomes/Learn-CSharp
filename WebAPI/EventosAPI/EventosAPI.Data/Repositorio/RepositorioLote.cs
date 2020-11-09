using EventosAPI.Data.Context;
using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Modelos;
using Microsoft.Extensions.Configuration;

namespace EventosAPI.Data.Repositorio
{
    public class RepositorioLote : RepositorioBase<Lote>, IRepositorioLote
    {
        #region Variáveis
        private readonly EventosContext _eventosContext;
        private readonly IConfiguration _configuration;
        private readonly string _stringConexao;
        #endregion

        #region Construtor
        public RepositorioLote(EventosContext eventosContext, IConfiguration configuration) : base(eventosContext)
        {
            _eventosContext = eventosContext;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }
        #endregion
    }
}
