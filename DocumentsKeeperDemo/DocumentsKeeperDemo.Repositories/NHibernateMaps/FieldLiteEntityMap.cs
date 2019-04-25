using DocumentsKeeperDemo.Core.Repositories.Entities;
using FluentNHibernate.Mapping;

namespace DocumentsKeeperDemo.Repositories.NHibernateMaps
{
    /// <summary>
    /// The field lite entity.
    /// </summary>
    public sealed class FieldLiteEntityMap : ClassMap<FieldLiteEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldLiteEntityMap"/> class.
        /// </summary>
        public FieldLiteEntityMap()
        {
            this.Table("FIELDS");

            this.Id(x => x.Id).Column("FIELD_GUID");

            this.Map(x => x.Name).Column("NAME");
            this.Map(x => x.FolderId).Column("FOLDER_GUID");
            this.Map(x => x.DisplayName).Column("DISPLAY_NAME");
            this.Map(x => x.DataType).Column("DATA_TYPE");
            this.Map(x => x.IsMultipleValue).Column("IS_MULTIPLE_VALUE");
        }
    }
}
