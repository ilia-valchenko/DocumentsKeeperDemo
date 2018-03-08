﻿using System.Web.Http;
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

            // Web API routes
            config.MapHttpAttributeRoutes();

	        var container = new UnityContainer();

	        config.DependencyResolver = new UnityResolver(container);

	        Bootstrapper.RegisterDependencies(container);
			Bootstrapper.RegisterMappings();

	        GlobalConfiguration.Configuration.Routes.MapHttpRoute(
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