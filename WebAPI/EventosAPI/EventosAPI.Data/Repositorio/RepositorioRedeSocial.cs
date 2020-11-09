using AcessoFacilSqlServer;
using EventosAPI.Data.Context;
using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Modelos;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EventosAPI.Data.Repositorio
{
    public class RepositorioRedeSocial : RepositorioBase<RedeSocial>, IRepositorioRedeSocial
    {
        #region Variáveis
        private EventosContext _eventosContext;
        private IConfiguration _configuration;
        private string _stringConexao;
        #endregion

        #region Construtor
        public RepositorioRedeSocial(EventosContext eventosContext, IConfiguration configuration) : base(eventosContext)
        {
            _eventosContext = eventosContext;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region ObterPorGrupoId
        public IEnumerable<RedeSocial> ObterPorGrupoId(int id)
        {
            List<RedeSocial> redesSociais = new List<RedeSocial>();

            using(Query query = new Query(_stringConexao))
            {
                if (id == 1)
                    query.Script = "select * from RedeSocial where EventoId is not null";
                else
                    query.Script = "select * from RedeSocial where PalestranteId is not null";

                query.Abrir();

                while (query.Proximo())
                {
                    if (id == 1)
                    {
                        redesSociais.Add(new RedeSocial()
                        {
                            RedeSocialId = query.ObterInteiro("RedeSocialId"),
                            Nome = query.ObterString("Nome"),
                            Url = query.ObterString("Url"),
                            EventoId = query.ObterInteiro("EventoId"),
                            PalestranteId = null
                        });
                    }

                    else
                    {
                        redesSociais.Add(new RedeSocial()
                        {
                            RedeSocialId = query.ObterInteiro("RedeSocialId"),
                            Nome = query.ObterString("Nome"),
                            Url = query.ObterString("Url"),
                            EventoId = null,
                            PalestranteId = query.ObterInteiro("PalestranteId")
                        });
                    }
                }

                return redesSociais;
            }
        }
        #endregion
    }
}
