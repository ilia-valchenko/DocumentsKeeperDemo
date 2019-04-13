using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Core.Enums;

namespace DocumentsKeeperDemo.Services.Models
{
	/// <summary>
	/// The document model.
	/// </summary>
	public sealed class DocumentModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentModel"/> class.
		/// </summary>
		public DocumentModel()
		{
			this.FieldValues = new List<FieldValueModel>();
		}

		/// <summary>
		/// The document's id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The document's number.
		/// </summary>
		public int DocumentNumber { get; set; }

		/// <summary>
		/// The file type.
		/// </summary>
		public FileType FileType { get; set; }

		/// <summary>
		/// The created date.
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// The folder.
		/// </summary>
		public FolderModel Folder { get; set; }

        /// <summary>
        /// The id of the folder.
        /// </summary>
        public Guid FolderId { get; set; }

		/// <summary>
		/// The collection of the field value models.
		/// </summary>
		public IList<FieldValueModel> FieldValues { get; set; }

		/// <summary>
		/// The text NAS path.
		/// </summary>
		public string TextNasPath { get; set; }

		/// <summary>
		/// The file size.
		/// </summary>
		public long FileSize { get; set; }

		/// <summary>
		/// The family id.
		/// </summary>
		public int FamilyId { get; set; }

		/// <summary>
		/// The upload id.
		/// </summary>
		public int UploadId { get; set; }

        /// <summary>
        /// The date of the document creation.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The date of the document modification.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
	}
}