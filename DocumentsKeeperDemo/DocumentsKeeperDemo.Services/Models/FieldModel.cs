using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Core.Enums;

namespace DocumentsKeeperDemo.Services.Models
{
	/// <summary>
	/// The field model.
	/// </summary>
	public sealed class FieldModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FieldModel"/> class.
		/// </summary>
		public FieldModel()
		{
			this.FieldValues = new List<FieldValueModel>();
		}

		/// <summary>
		/// The field's id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The name of the field.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The display name of the field.
		/// </summary>
		public string DisplayName { get; set; }

		/// <summary>
		/// The field's data type.
		/// </summary>
		public FieldDataType DataType { get; set; }

		/// <summary>
		/// Indicates field is multiple value.
		/// </summary>
		public bool IsMultipleValue { get; set; }

		/// <summary>
		/// The folder.
		/// </summary>
		public FolderModel Folder { get; set; }

        /// <summary>
        /// The id of the folder the field belong to.
        /// </summary>
        public Guid FolderId { get; set; }

		/// <summary>
		/// The collection of the field values.
		/// </summary>
		public IList<FieldValueModel> FieldValues { get; set; }
	}
}
