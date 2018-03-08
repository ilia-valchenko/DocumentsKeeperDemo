namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
	/// <summary>
	/// The base database entity.
	/// </summary>
	public class BaseDatabaseEntity
	{
		/// <summary>
		/// The identifier.
		/// </summary>
		public virtual string Id { get; set; }

		/// <summary>
		/// The resource status.
		/// </summary>
		public virtual string ResourceStatus { get; set; }
	}
}
