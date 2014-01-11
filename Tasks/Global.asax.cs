using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Tasks.App_Start;
using Tasks.Models;

namespace Tasks
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            SetupFakeDatabase();
        }

        private static void SetupFakeDatabase()
        {
            HttpContext.Current.Cache.Add(
                "tasks",
                new List<TaskModel>
                    {
                        new TaskModel("Implementation", "Daniel")
                    },
                null,
                Cache.NoAbsoluteExpiration,
                TimeSpan.Zero,
                CacheItemPriority.Default,
                (key, value, reason) => { });

            HttpContext.Current.Cache.Add(
                "people",
                new List<Person>
                    {
                        new Person("Daniel"),
                        new Person("Johan"),
                        new Person("Fredrik"),
                        new Person("Sandra"),
                        new Person("Klas"),
                        new Person("Nina")
                    },
                null,
                Cache.NoAbsoluteExpiration,
                TimeSpan.Zero,
                CacheItemPriority.Default,
                (key, value, reason) => { });
        }
    }
}