using DocumentsKeeperDemo.Core.Repositories.Entities;
using FluentNHibernate.Mapping;

namespace DocumentsKeeperDemo.Repositories.NHibernateMaps
{
	/// <summary>
	/// The field value entity map.
	/// </summary>
	public sealed class FieldValueEntityMap : ClassMap<FieldValueEntity>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FieldValueEntityMap"/> class.
		/// </summary>
		public FieldValueEntityMap()
		{
			this.Table("FIELD_VALUES");

			this.Id(x => x.Id).Column("FIELD_VALUE_GUID");

			this.Map(x => x.TextValue).Column("TEXT_VALUE");
			this.Map(x => x.NumericValue).Column("NUMERIC_VALUE");
			this.Map(x => x.BooleanValue).Column("BOOLEAN_VALUE");
			this.Map(x => x.DateTimeValue).Column("DATETIME_VALUE");

//			this.References(x => x.Document)
//				.ForeignKey("DOCUMENT_GUID");
//
//			this.References(x => x.Field)
//				.ForeignKey("FIELD_GUID");
		}
	}
}
