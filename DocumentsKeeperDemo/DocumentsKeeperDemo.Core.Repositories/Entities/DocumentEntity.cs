using System;
using System.Collections.Generic;

namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
	/// <summary>
	/// The document entity.
	/// </summary>
	public class DocumentEntity : BaseDatabaseEntity
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentEntity"/> class.
        /// </summary>
        public DocumentEntity()
		{
			this.FieldValues = new List<FieldValueEntity>();
		}

		/// <summary>
		/// The document number.
		/// </summary>
		public virtual int DocumentNumber { get; set; }

		/// <summary>
		/// The document file type.
		/// </summary>
		public virtual string FileType { get; set; }

		/// <summary>
		/// The created date.
		/// </summary>
		public virtual DateTime CreatedDate { get; set; }

		/// <summary>
		/// The folder entity.
		/// </summary>
		public virtual FolderEntity Folder { get; set; }

		/// <summary>
		/// The collection of the field value entities.
		/// </summary>
		public virtual IList<FieldValueEntity> FieldValues { get; set; }

		/// <summary>
		/// The text Nas path.
		/// </summary>
		public virtual string TextNasPath { get; set; }

		/// <summary>
		/// The file size.
		/// </summary>
		public virtual long FileSize { get; set; }

		/// <summary>
		/// The document family identifier.
		/// </summary>
		public virtual int FamilyId { get; set; }

		/// <summary>
		/// The upload identifier.
		/// </summary>
		public virtual int UploadId { get; set; }
	}
}
