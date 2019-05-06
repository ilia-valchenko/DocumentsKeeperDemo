using DocumentsKeeperDemo.Repositories.Infrastructure;
using DocumentsKeeperDemo.Repositories.Infrastructure.ElasticSearch;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Repositories.Repositories;
using Nest;
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
			container.RegisterType<ISessionFactory>(
                new InjectionFactory(c => c.Resolve<IFactorySessionFactory>()
                    .CreateSessionFactory()));

            container.RegisterType<IElasticClientFactory, ElasticClientFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IElasticClient>(
                new InjectionFactory((c) => c.Resolve<IElasticClientFactory>()
                    .CreateElasticClient()));

            container.RegisterType<IDocumentRepository, DocumentRepository>(new HierarchicalLifetimeManager());
		    container.RegisterType<IFolderRepository, FolderRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFieldRepository, FieldRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFieldValueRepository, FieldValueRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IElasticRepository, ElasticRepository>(new HierarchicalLifetimeManager());
        }
	}
}