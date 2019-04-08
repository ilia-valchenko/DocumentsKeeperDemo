using System;
using System.Collections.Generic;

namespace DocumentsKeeperDemo.Services.Models
{
	/// <summary>
	/// The folder model class.
	/// </summary>
	public sealed class FolderModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FolderModel"/> class.
		/// </summary>
		public FolderModel()
		{
			this.Documents = new List<DocumentModel>();
			this.Fields = new List<FieldModel>();
		}

		/// <summary>
		/// The folder's identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The name of the folder.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The collection of the documents.
		/// </summary>
		public IEnumerable<DocumentModel> Documents { get; set; }

		/// <summary>
		/// The collection of the fields.
		/// </summary>
		public IEnumerable<FieldModel> Fields { get; set; }

		/// <summary>
		/// The created date.
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// The last modified date.
		/// </summary>
		public DateTime LastModified { get; set; }
	}
}
