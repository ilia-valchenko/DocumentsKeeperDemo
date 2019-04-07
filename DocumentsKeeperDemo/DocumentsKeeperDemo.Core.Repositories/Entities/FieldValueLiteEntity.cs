using System;

namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
    /// <summary>
    /// The lite field value entity that contains general information about
    /// the field value.
    /// </summary>
    public class FieldValueLiteEntity : BaseDatabaseEntity
    {
        /// <summary>
		/// The document id that the field value belong to.
		/// </summary>
		public virtual string DocumentId { get; set; }

        /// <summary>
        /// The field id that the field value belong to.
        /// </summary>
        public virtual string FieldId { get; set; }

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