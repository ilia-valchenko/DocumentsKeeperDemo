using DocumentsKeeperDemo.Repositories.NHibernateMaps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DocumentsKeeperDemo.Repositories.Infrastructure
{
	/// <summary>
	/// The factory session factory.
	/// </summary>
	public sealed class FactorySessionFactory : IFactorySessionFactory
	{
		/// <summary>
		/// Creates the implementation of the <see cref="ISessionFactory"/> interface.
		/// </summary>
		/// <returns>
		/// The implementation of the <see cref="ISessionFactory"/> interface.
		/// </returns>
		public ISessionFactory CreateSessionFactory() => Fluently.Configure()
			//.Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("connectionString")).ShowSql())
			.Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\git\DocumentsKeeper\DocumentsKeeperDemo\DocumentsKeeperDemo.Web\App_Data\DocumentsKeeperDemoDatabase.mdf;Integrated Security=True").ShowSql())
			.Mappings(m => m.FluentMappings.AddFromAssemblyOf<DocumentEntityMap>())
			.BuildSessionFactory();
	}
}
