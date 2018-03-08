using NHibernate;

namespace DocumentsKeeperDemo.Repositories.Infrastructure
{
	/// <summary>
	/// The factory session factory interface.
	/// </summary>
	public interface IFactorySessionFactory
	{
		/// <summary>
		/// Creates the implementation of the <see cref="ISessionFactory"/> interface.
		/// </summary>
		/// <returns>
		/// The implementation of the <see cref="ISessionFactory"/> interface.
		/// </returns>
		ISessionFactory CreateSessionFactory();
	}
}
