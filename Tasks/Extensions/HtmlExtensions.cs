using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Tasks.Extensions
{
    public static class HtmlExtensions
    {
        public static HtmlString ToJson<T>(this HtmlHelper helper, T obj, Formatting formatting = Formatting.Indented)
        {
            // converts into camelCase
            var serializer = new JsonSerializer
                {
                    Formatting = formatting,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
            var builder = new StringBuilder();
            serializer.Serialize(new StringWriter(builder), obj);
            return new HtmlString(builder.ToString());
        }
    }
}