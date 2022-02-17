using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CO2API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            // login is for testing only and as it stands rigth now it is not used.
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
               name: "login",
               routeTemplate: "api/{controller}/{action}/{id}/{pass}",
               defaults: new { id = RouteParameter.Optional, pas = RouteParameter.Optional }
           );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
