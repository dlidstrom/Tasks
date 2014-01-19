using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Tasks.App_Start;
using Tasks.Infrastructure;
using Tasks.Migrations;
using Tasks.Models;

namespace Tasks
{
    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            CreateContainer();
            var strategy = new MigrateDatabaseToLatestVersion<
                Context,
                Configuration>();
            Database.SetInitializer(strategy);
        }

        private static void CreateContainer()
        {
            container = new WindsorContainer().Install(
                new ControllerInstaller(),
                new WindsorWebApiInstaller(),
                new ControllerFactoryInstaller(),
                new ContextInstaller());

            DependencyResolver.SetResolver(new WindsorMvcDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new WindsorHttpDependencyResolver(container.Kernel);
        }
    }
}