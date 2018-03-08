using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Core.Enums;

namespace DocumentsKeeperDemo.Web.Api.V1.ViewModels
{
	/// <summary>
	/// The field view model class.
	/// </summary>
	public sealed class FieldViewModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FieldViewModel"/> class.
		/// </summary>
		public FieldViewModel()
		{
			this.FieldValues = new List<FieldValueViewModel>();
		}

		/// <summary>
		/// The field view model's id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The field's name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The field's display name.
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
		public FolderViewModel Folder { get; set; }

		/// <summary>
		/// The collection of field values.
		/// </summary>
		public IList<FieldValueViewModel> FieldValues { get; set; }
	}
}