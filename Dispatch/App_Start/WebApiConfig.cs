using Dispatch.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
            //    name: "ChromeRoute",
            //    routeTemplate: "api/today/DayOfWeek",
            //    defaults: new { controller = "today", action = "dayofweek" },
            //    constraints: new { useragent = new UserAgentConstraint("chrome") }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "NotChromeRoute",
            //    routeTemplate: "api/today/DayOfWeek",
            //    defaults: new { controller = "today", action = "daynumber" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "IncludeAction",
            //    routeTemplate: "api/today/{action}/{day}",
            //    defaults: new { controller = "today", day = 6 }
            //);

            config.Routes.MapHttpRoute(
                name: "ChromeRoute",
                routeTemplate: "api/today/{action}",
                defaults: new { controller = "today" },
                constraints: new
                {
                    useragent = new UserAgentConstraint("Chrome"),
                    action = new RegexRouteConstraint("daynumber|othermethod")
                }
            );

            config.Routes.MapHttpRoute(
                name: "NotChromeRoute",
                routeTemplate: "api/today/DayOfWeek",
                defaults: new { controller = "today", action = "daynumber" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
