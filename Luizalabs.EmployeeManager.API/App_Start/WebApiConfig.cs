using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Luizalabs.EmployeeManager.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "EmployeeApi",
            //    routeTemplate: "{controller}/{page_size}/{page}",
            //    defaults: new { page_size = RouteParameter.Optional, page = RouteParameter.Optional }
            //);
        }
    }
}
