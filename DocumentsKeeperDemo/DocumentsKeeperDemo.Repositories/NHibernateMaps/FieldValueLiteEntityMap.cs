using DocumentsKeeperDemo.Core.Repositories.Entities;
using FluentNHibernate.Mapping;

namespace DocumentsKeeperDemo.Repositories.NHibernateMaps
{
    /// <summary>
    /// The field value lite entity map.
    /// </summary>
    public sealed class FieldValueLiteEntityMap : ClassMap<FieldValueLiteEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValueLiteEntityMap"/> class.
        /// </summary>
        public FieldValueLiteEntityMap()
        {
            this.Table("FIELD_VALUES");

            this.Id(x => x.Id).Column("FIELD_VALUE_GUID");

            this.Map(x => x.DocumentId).Column("DOCUMENT_GUID");
            this.Map(x => x.FieldId).Column("FIELD_GUID");
            this.Map(x => x.TextValue).Column("TEXT_VALUE");
            this.Map(x => x.NumericValue).Column("NUMERIC_VALUE");
            this.Map(x => x.BooleanValue).Column("BOOLEAN_VALUE");
            this.Map(x => x.DateTimeValue).Column("DATETIME_VALUE");
        }
    }
}