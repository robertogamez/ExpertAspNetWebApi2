﻿using ExampleApp.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Net.Http.Formatting;
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
                name: "API with extension",
                routeTemplate: "api/{controller}.{ext}/{id}",
                defaults: new { id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Binding Example",
                routeTemplate: "api/{controller}/{action}/{first}/{second}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}

