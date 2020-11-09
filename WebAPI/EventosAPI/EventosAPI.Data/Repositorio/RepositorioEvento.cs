using AcessoFacilSqlServer;
using EventosAPI.Data.Context;
using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace EventosAPI.Data.Repositorio
{
    public class RepositorioEvento : RepositorioBase<Evento>, IRepositorioEvento
    {
        #region Variáveis
        private readonly EventosContext _eventosContext;
        private readonly IConfiguration _configuration;
        private readonly string _stringConexao;
        #endregion

        #region Construtor
        public RepositorioEvento(EventosContext eventosContext, IConfiguration configuration) : base(eventosContext)
        {
            _eventosContext = eventosContext;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region ObterEventoPorTemaLinq
        public Evento ObterEventoPorTemaLinq(string tema)
        {
            IQueryable<Evento> query = _eventosContext.Evento;

            return query.Where(x => x.Tema == tema).AsNoTracking().FirstOrDefault();
        }
        #endregion

        #region ObterEventoPorTema
        public Evento ObterEventoPorTema(string tema)
        {
            using(Query query = new Query(_stringConexao))
            {
                query.Script = "select * from evento " +
                               "where tema = @tema   ";
                query.AdicionarParametro("tema", tema);
                query.Abrir();

                while (query.Proximo())
                {
                    return new Evento() {
                        EventoId = query.ObterInteiro("Eventoid"),
                        Endereco = query.ObterString("Endereco"),
                        DataEvento = query.ObterDateTime("DataEvento"),
                        QtdPessoas = query.ObterInteiro("QtdPessoas"),
                        ImagemUrl = query.ObterString("ImagemUrl"),
                        Telefone = query.ObterInteiro("Telefone"),
                        Tema = query.ObterString("TEMA")
                        };
                }
                return null;
            }
        }
        #endregion

        #region ObterEventoPorData
        public Evento ObterEventoPorData(DateTime? data)
        {
            using(Query query = new Query(_stringConexao))
            {
                if (data == null)
                    return null;

                else
                {
                    query.Script = "select * from evento where DataEvento = @data";
                    query.AdicionarParametro("data", data);
                    query.Abrir();
                }
                
                while (query.Proximo())
                {
                    return new Evento()
                    {
                        EventoId = query.ObterInteiro("Eventoid"),
                        Endereco = query.ObterString("Endereco"),
                        DataEvento = query.ObterDateTime("DataEvento"),
                        QtdPessoas = query.ObterInteiro("QtdPessoas"),
                        ImagemUrl = query.ObterString("ImagemUrl"),
                        Telefone = query.ObterInteiro("Telefone"),
                        Tema = query.ObterString("TEMA")
                    };
                }
                return null;
            }
        }
        #endregion
    }
}
