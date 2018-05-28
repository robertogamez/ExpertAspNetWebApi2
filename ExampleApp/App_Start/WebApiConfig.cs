using ExampleApp.Infrastructure;
using System.Web.Http;

namespace ExampleApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Services.Replace(typeof(IContentNegotiator), new CustomNegotiator());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Formatters
            config.Formatters.Add(new ProductFormatter());
        }
    }
}
