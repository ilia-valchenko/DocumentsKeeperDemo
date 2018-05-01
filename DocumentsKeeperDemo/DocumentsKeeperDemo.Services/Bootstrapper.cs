using System.Collections.Generic;
using AutoMapper;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Registrars;
using DocumentsKeeperDemo.Services.Services;
using Unity;
using Unity.Lifetime;

namespace DocumentsKeeperDemo.Services
{
	/// <summary>
	/// The service layer bootstrapper.
	/// </summary>
	public static class Bootstrapper
	{
		/// <summary>
		/// Registers dependecies on the service layer.
		/// </summary>
		/// <param name="container">The unity container.</param>
		public static void RegisterDependencies(IUnityContainer container)
		{
			Repositories.Bootstrapper.RegisterDependencies(container);

			container.RegisterType<IDocumentService, DocumentService>(new HierarchicalLifetimeManager());
		    container.RegisterType<IFolderService, FolderService>(new HierarchicalLifetimeManager());
		}

		/// <summary>
		/// Registers mappings on the service layer.
		/// </summary>
		/// <param name="profiles">The profiles.</param>
		public static void RegisterMappings(IList<Profile> profiles)
		{
			//Mapper.Initialize(cfg => cfg.AddProfile(typeof(AutoMapperProfile)));
			profiles.Add(new AutoMapperProfile());
		}
	}
}
