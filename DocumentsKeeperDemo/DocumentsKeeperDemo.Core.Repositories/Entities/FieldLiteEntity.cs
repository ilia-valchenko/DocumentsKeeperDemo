namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
    /// <summary>
    /// The field lite entity.
    /// </summary>
    public class FieldLiteEntity : BaseDatabaseEntity
    {
        /// <summary>
        /// The field's name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// The id of the folder the field belong to.
        /// </summary>
        public virtual string FolderId { get; set; }

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
    }
}
