using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Tasks.Data.Migrations;
using Tasks.Data.Models;
using Tasks.Infrastructure;

namespace Tasks
{
    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer container;

        public static void Configure(
            IWindsorContainer windsorContainer,
            HttpConfiguration configuration)
        {
            container = windsorContainer;

            //AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var strategy = new MigrateDatabaseToLatestVersion<
                Context,
                Configuration>();
            Database.SetInitializer(strategy);
            DependencyResolver.SetResolver(new WindsorMvcDependencyResolver(container));
            configuration.DependencyResolver =
                new WindsorHttpDependencyResolver(container.Kernel);
        }

        public static void Shutdown()
        {
            RouteTable.Routes.Clear();
            container.Dispose();
        }

        protected void Application_Start()
        {
            Configure(CreateContainer(), GlobalConfiguration.Configuration);
        }

        private static IWindsorContainer CreateContainer()
        {
            return new WindsorContainer().Install(
                new ControllerInstaller(),
                new WindsorWebApiInstaller(),
                new ControllerFactoryInstaller(),
                new ContextInstaller());
        }
    }
}