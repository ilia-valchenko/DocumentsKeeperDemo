using System;

namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
	/// <summary>
	/// The field value entity.
	/// </summary>
	public class FieldValueEntity : BaseDatabaseEntity
	{
		/// <summary>
		/// The document entity.
		/// </summary>
		public virtual DocumentEntity Document { get; set; }

		/// <summary>
		/// The field entity.
		/// </summary>
		public virtual FieldEntity Field { get; set; }

		/// <summary>
		/// The text value.
		/// </summary>
		public virtual string TextValue { get; set; }

		/// <summary>
		/// The numberic value.
		/// </summary>
		public virtual int NumericValue { get; set; }

		/// <summary>
		/// The boolean value.
		/// </summary>
		public virtual bool BooleanValue { get; set; }

		/// <summary>
		/// The datetime value.
		/// </summary>
		public virtual DateTime DateTimeValue { get; set; }
	}
}
