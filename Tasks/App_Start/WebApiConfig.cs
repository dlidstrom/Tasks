using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Tasks.Infrastructure;

// ReSharper disable CheckNamespace
namespace Tasks
// ReSharper restore CheckNamespace
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Filters.Add(new SaveChangesAttribute());

            // camelCase by default
            var formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}