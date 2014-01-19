using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tasks.Data.Models;

namespace Tasks.Infrastructure
{
    public class ContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbContext>()
                         .ImplementedBy<Context>()
                         .LifestylePerWebRequest());
        }
    }
}