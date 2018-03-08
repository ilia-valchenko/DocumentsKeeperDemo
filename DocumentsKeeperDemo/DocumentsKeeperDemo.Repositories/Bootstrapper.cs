using DocumentsKeeperDemo.Repositories.Infrastructure;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Repositories.Repositories;
using NHibernate;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace DocumentsKeeperDemo.Repositories
{
	/// <summary>
	/// The repository level bootstrapper.
	/// </summary>
	public static class Bootstrapper
	{
		/// <summary>
		/// Registers dependecies on repository level.
		/// </summary>
		/// <param name="container">The unity container.</param>
		public static void RegisterDependencies(IUnityContainer container)
		{
			container.RegisterType<IFactorySessionFactory, FactorySessionFactory>(new ContainerControlledLifetimeManager());
			container.RegisterType<ISessionFactory>(new InjectionFactory(c => c.Resolve<IFactorySessionFactory>().CreateSessionFactory()));

			container.RegisterType<IDocumentRepository, DocumentRepository>(new HierarchicalLifetimeManager());
		}
	}
}
