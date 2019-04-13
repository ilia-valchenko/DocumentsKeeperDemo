using System;

namespace DocumentsKeeperDemo.Services.Models
{
	/// <summary>
	/// The field value model class.
	/// </summary>
	public sealed class FieldValueModel
	{
		/// <summary>
		/// The field value's id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The document.
		/// </summary>
		public DocumentModel Document { get; set; }

        /// <summary>
        /// The id of the document that field value belong to.
        /// </summary>
        public Guid DocumentId { get; set; }

		/// <summary>
		/// The field.
		/// </summary>
		public FieldModel Field { get; set; }

        /// <summary>
        /// The id of the field that the field value belong to.
        /// </summary>
        public Guid FieldId { get; set; }

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

        /// <summary>
        /// The date of the field value creation.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The date of the field value modification.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}