using System.Net.Http;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;
using Tasks.Infrastructure;
using Tasks.Models;

namespace Tasks.Tests
{
    public abstract class WebApiIntegrationTest
    {
        protected InMemoryDbContext Context { get; set; }

        protected HttpClient Client { get; set; }

        [SetUp]
        public void SetUp()
        {
            Context = new InMemoryDbContext();
            var configuration = new HttpConfiguration();
            var container = new WindsorContainer();
            container.Install(new ControllerInstaller(),
                              new WindsorWebApiInstaller(),
                              new ControllerFactoryInstaller());
            container.Register(Component.For<IDbContext>().Instance(Context));
            MvcApplication.Configure(container, configuration);
            Client = new HttpClient(new HttpServer(configuration));
            OnSetUp();
        }

        protected virtual void OnSetUp()
        {
        }
    }
}