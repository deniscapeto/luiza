using Luizalabs.EmployeeManager.API.DAL;
using Luizalabs.EmployeeManager.API.Models;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Luizalabs.EmployeeManager.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>(new HierarchicalLifetimeManager());
            container.RegisterInstance<IEmployeeContext>(EmployeeContextFactory.GetInstance());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
