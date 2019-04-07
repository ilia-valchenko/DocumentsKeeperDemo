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

        // TODO: Put the connection string into config file.
        //.Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("connectionString")).ShowSql())

        //// Disabled by Azure. 
        //.Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Server=tcp:documentskeeperdemodatabaseserver.database.windows.net,1433;Initial Catalog=DocumentsKeeperDemoDatabase;Persist Security Info=False;User ID=valchenko;Password=Master_2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;").ShowSql())
        //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<DocumentEntityMap>())
        //.BuildSessionFactory();

        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\iValc\Downloads\git\DocumentsKeeperDemo\DocumentsKeeperDemo\DocumentsKeeperDemo.Web\App_Data\Database\DocumentsKeeperDatabase.mdf;Integrated Security=True").ShowSql())
        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DocumentEntityMap>())  
        .BuildSessionFactory();
    }
}
