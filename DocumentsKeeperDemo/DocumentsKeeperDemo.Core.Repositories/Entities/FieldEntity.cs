using System.Collections.Generic;

namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
	/// <summary>
	/// The field entity.
	/// </summary>
	public class FieldEntity : BaseDatabaseEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FieldEntity"/> class.
		/// </summary>
		public FieldEntity()
		{
			this.FieldValues = new List<FieldValueEntity>();
		}

		/// <summary>
		/// The field's name.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// The field's display name.
		/// </summary>
		public virtual string DisplayName { get; set; }

		/// <summary>
		/// The field data type.
		/// </summary>
		public virtual string DataType { get; set; }

		/// <summary>
		/// Is multiple value field.
		/// </summary>
		public virtual bool IsMultipleValue { get; set; }

		/// <summary>
		/// The folder entity.
		/// </summary>
		public virtual FolderEntity Folder { get; set; }

		/// <summary>
		/// The collection of the field value entities.
		/// </summary>
		public virtual IList<FieldValueEntity> FieldValues { get; set; }
	}
}
