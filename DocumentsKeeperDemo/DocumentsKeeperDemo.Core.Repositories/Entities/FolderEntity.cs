using System;
using System.Collections.Generic;

namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
	/// <summary>
	/// The folder entity class.
	/// </summary>
	public class FolderEntity : BaseDatabaseEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FolderEntity"/> class.
		/// </summary>
		public FolderEntity()
		{
			this.Documents = new List<DocumentEntity>();
			this.Fields = new List<FieldEntity>();
		}

		/// <summary>
		/// The name of the folder.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// The collection of the document entities.
		/// </summary>
		public virtual IList<DocumentEntity> Documents { get; set; }

		/// <summary>
		/// The collection of the field entities.
		/// </summary>
		public virtual IList<FieldEntity> Fields { get; set; }
	}
}
