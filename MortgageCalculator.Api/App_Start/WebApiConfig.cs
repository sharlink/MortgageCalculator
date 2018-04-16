using System.Configuration;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MortgageCalculator.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //CORS Enable           
            var cors = new EnableCorsAttribute(ConfigurationManager.AppSettings["MortgageCalculator.Web"].ToString(), "*", "GET, POST, PUT, DELETE, OPTIONS");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("acceptFormat", "xml", new MediaTypeHeaderValue("application/xml")));
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("acceptFormat", "json", new MediaTypeHeaderValue("application/json")));
        }
    }
}
