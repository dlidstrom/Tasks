using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Tasks.Infrastructure
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().LifestyleTransient());
        }

        private static BasedOnDescriptor FindControllers()
        {
            return Classes.FromThisAssembly()
                          .BasedOn<IController>()
                          .Configure(c => c.Named(c.Implementation.Name));
        }
    }
}