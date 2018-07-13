using Dispatch.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing.Constraints;

namespace Dispatch
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "ActionMethods",
            //    routeTemplate: "api/{controller}/{action}/{day}",
            //    defaults: new { day = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Services.Replace(
                typeof(IHttpActionSelector),
                new PipelineActionSelector()
            );

            config.Filters.Add(new SayHelloAttribute
            {
                Message = "Global Filter"
            });
        }
    }
}
