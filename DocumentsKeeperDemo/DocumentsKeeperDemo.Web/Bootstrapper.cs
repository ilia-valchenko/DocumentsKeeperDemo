using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DocumentsKeeperDemo.Web.Registrars;
using Unity;

namespace DocumentsKeeperDemo.Web
{
	/// <summary>
	/// The presentation layer bootstrapper.
	/// </summary>
	public static class Bootstrapper
	{
		/// <summary>
		/// Registers dependecies on the presentation layer.
		/// </summary>
		/// <param name="container">The unity container.</param>
		public static void RegisterDependencies(IUnityContainer container)
		{
			Services.Bootstrapper.RegisterDependencies(container);
		}

		/// <summary>
		/// Registers mappings on the presentation layer.
		/// </summary>
		public static void RegisterMappings()
		{
			var profilers = new List<Profile>
			{
				new AutoMapperProfile()
			};

			Services.Bootstrapper.RegisterMappings(profilers);

			Mapper.Initialize(cfg => cfg.AddProfiles(profilers.Select(p => p.GetType())));
		}
	}
}