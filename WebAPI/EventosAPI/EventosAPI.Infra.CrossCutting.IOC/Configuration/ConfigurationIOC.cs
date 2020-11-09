using Autofac;
using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Servicos;
using EventosAPI.Data.Repositorio;
using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using EventosAPI.Servico.Servicos;

namespace EventosAPI.Infra.CrossCutting.IOC.Configuration
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Applications
            builder.RegisterType<ServicoAplicacaoConvidado>().As<IServicoAplicacaoConvidado>();
            builder.RegisterType<ServicoAplicacaoEvento>().As<IServicoAplicacaoEvento>();
            builder.RegisterType<ServicoAplicacaoLote>().As<IServicoAplicacaoLote>();
            builder.RegisterType<ServicoAplicacaoPalestrante>().As<IServicoAplicacaoPalestrante>();
            builder.RegisterType<ServicoAplicacaoPalestranteEvento>().As<IServicoAplicacaoPalestranteEvento>();
            builder.RegisterType<ServicoAplicacaoRedeSocial>().As<IServicoAplicacaoRedeSocial>();
            #endregion


            #region IOC Services
            builder.RegisterType<ConvidadoAPIServico>().As<IConvidadoAPIServico>();
            builder.RegisterType<EventosAPIServico>().As<IEventosAPIServico>();
            builder.RegisterType<LoteAPIServico>().As<ILoteAPIServico>();
            builder.RegisterType<PalestranteAPIServico>().As<IPalestranteAPIServico>();
            builder.RegisterType<PalestranteEventoAPIServico>().As<IPalestranteEventoAPIServico>();
            builder.RegisterType<RedeSocialAPIServico>().As<IRedeSocialAPIServico>();
            #endregion


            #region IOC Repositorys SQL
            builder.RegisterType<RepositorioConvidado>().As<IRepositorioConvidado>();
            builder.RegisterType<RepositorioEvento>().As<IRepositorioEvento>();
            builder.RegisterType<RepositorioLote>().As<IRepositorioLote>();
            builder.RegisterType<RepositorioPalestrante>().As<IRepositorioPalestrante>();
            builder.RegisterType<RepositorioPalestranteEvento>().As<IRepositorioPalestranteEvento>();
            builder.RegisterType<RepositorioRedeSocial>().As<IRepositorioRedeSocial>();
            #endregion

            #endregion
        }
    }
}
