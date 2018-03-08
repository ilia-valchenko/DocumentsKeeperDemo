using System;
using System.Collections.Generic;

namespace DocumentsKeeperDemo.Web.Api.V1.ViewModels
{
	/// <summary>
	/// The folder view model class.
	/// </summary>
	public sealed class FolderViewModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FolderViewModel"/> class.
		/// </summary>
		public FolderViewModel()
		{
			this.Documents = new List<DocumentViewModel>();
			this.Fields = new List<FieldViewModel>();
		}

		/// <summary>
		/// The folder's id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The name of the folder.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The collection of the documents.
		/// </summary>
		public IList<DocumentViewModel> Documents { get; set; }

		/// <summary>
		/// The collection of the fields.
		/// </summary>
		public IList<FieldViewModel> Fields { get; set; }

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