using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Core.Enums;

namespace DocumentsKeeperDemo.Web.Api.V1.ViewModels
{
	/// <summary>
	/// The document view model class.
	/// </summary>
	public sealed class DocumentViewModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentViewModel"/> class.
		/// </summary>
		public DocumentViewModel()
		{
			this.FieldValues = new List<FieldValueViewModel>();
		}

		/// <summary>
		/// The document view model's id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The document number.
		/// </summary>
		public int DocumentNumber { get; set; }

		/// <summary>
		/// The document's file type.
		/// </summary>
		public string FileType { get; set; }

		/// <summary>
		/// The folder.
		/// </summary>
		public FolderViewModel Folder { get; set; }

		/// <summary>
		/// The collection of the field values.
		/// </summary>
		public IList<FieldValueViewModel> FieldValues { get; set; }

		/// <summary>
		/// The test NAS path.
		/// </summary>
		public string TextNasPath { get; set; }

		/// <summary>
		/// The document file size.
		/// </summary>
		public long FileSize { get; set; }

		/// <summary>
		/// The document's family id.
		/// </summary>
		public int FamilyId { get; set; }

		/// <summary>
		/// The upload id.
		/// </summary>
		public int UploadId { get; set; }
	}
}