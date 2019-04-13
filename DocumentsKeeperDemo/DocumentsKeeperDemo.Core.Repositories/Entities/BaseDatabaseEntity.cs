using System;

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
        /// The date of creation of the record.
        /// </summary>
        public virtual DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date of the record modification.
        /// </summary>
        public virtual DateTime ModifiedDate { get; set; }
	}
}