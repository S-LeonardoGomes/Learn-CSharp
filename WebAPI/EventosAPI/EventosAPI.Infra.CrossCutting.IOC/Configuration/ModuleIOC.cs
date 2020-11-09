using Autofac;

namespace EventosAPI.Infra.CrossCutting.IOC.Configuration
{
    public class ModuleIOC : Module
    {
        #region Carregar IOC
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOC.Load(builder);
        }

        #endregion
    }
}
