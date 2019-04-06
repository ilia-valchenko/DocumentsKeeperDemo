using DocumentsKeeperDemo.Web.Filters;
using System.Web.Http;
using Unity;

namespace DocumentsKeeperDemo.Web
{
	/// <summary>
	/// The web api config.
	/// </summary>
    public static class WebApiConfig
    {
		/// <summary>
		/// Registers routes.
		/// </summary>
		/// <param name="config">The http configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Filters
            config.Filters.Add(new ApplicationExceptionFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Enable CORS
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            var container = new UnityContainer();

	        config.DependencyResolver = new UnityResolver(container);

	        Bootstrapper.RegisterDependencies(container);
			Bootstrapper.RegisterMappings();

            config.Routes.MapHttpRoute(
                name: "DocumentRouteWithAction",
                routeTemplate: "api/{version}/{controller}/{action}/{documentId}",
                defaults: new { controller = "Documents", version = "v1", documentId = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "FolderRouteWithAction",
                routeTemplate: "api/{version}/{controller}/{action}/{folderId}",
                defaults: new { controller = "Folders", version = "v1", folderId = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DocumentRoute",
                routeTemplate: "api/{version}/{controller}/{documentId}",
                defaults: new { controller = "Documents", version = "v1", documentId = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
