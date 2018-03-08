using System;

namespace DocumentsKeeperDemo.Web.Api.V1.ViewModels
{
	/// <summary>
	/// The field value view model class.
	/// </summary>
	public sealed class FieldValueViewModel
	{
		/// <summary>
		/// The field value's id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The document.
		/// </summary>
		public DocumentViewModel Document { get; set; }

		/// <summary>
		/// The field.
		/// </summary>
		public FieldViewModel Field { get; set; }

		/// <summary>
		/// The text value.
		/// </summary>
		public string TextValue { get; set; }

		/// <summary>
		/// The numeric value.
		/// </summary>
		public int NumericValue { get; set; }

		/// <summary>
		/// The boolean value.
		/// </summary>
		public bool BooleanValue { get; set; }

		/// <summary>
		/// The datetime value.
		/// </summary>
		public DateTime DateTimeValue { get; set; }
	}
}