using DocumentsKeeperDemo.Core.Repositories.Entities;
using FluentNHibernate.Mapping;

namespace DocumentsKeeperDemo.Repositories.NHibernateMaps
{
	/// <summary>
	/// The field entity map.
	/// </summary>
	public sealed class FieldEntityMap : ClassMap<FieldEntity>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FieldEntityMap"/> class.
		/// </summary>
		public FieldEntityMap()
		{
			this.Table("FIELDS");

			this.Id(x => x.Id).Column("FIELD_GUID");

            this.Map(x => x.Name).Column("NAME");
            this.Map(x => x.FolderId).Column("FOLDER_GUID");
			this.Map(x => x.DisplayName).Column("DISPLAY_NAME");
			this.Map(x => x.DataType).Column("DATA_TYPE");
			this.Map(x => x.IsMultipleValue).Column("IS_MULTIPLE_VALUE");

            //this.HasMany(x => x.FieldValues)
            //    .Table("FIELD_VALUES")
            //    .KeyColumn("FIELD_GUID")
            //    .Not.LazyLoad();

            //References(x => x.FolderId)
            //    .Column("FOLDER_GUID")
            //    .Cascade.All();

            References(x => x.Folder)
                .Column("FOLDER_GUID")
                .Cascade.All();
        }
	}
}
