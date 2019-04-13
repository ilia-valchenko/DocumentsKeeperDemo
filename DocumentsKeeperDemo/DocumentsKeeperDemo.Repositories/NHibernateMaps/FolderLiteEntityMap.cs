using DocumentsKeeperDemo.Core.Repositories.Entities;
using FluentNHibernate.Mapping;

namespace DocumentsKeeperDemo.Repositories.NHibernateMaps
{
    /// <summary>
    /// The folder lite enttiy map.
    /// </summary>
    public sealed class FolderLiteEntityMap : ClassMap<FolderLiteEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderLiteEntityMap"/> class.
        /// </summary>
        public FolderLiteEntityMap()
        {
            this.Table("FOLDERS");

            this.Id(x => x.Id).Column("FOLDER_GUID");

            this.Map(x => x.Name).Column("NAME");
            this.Map(x => x.CreatedDate).Column("CREATED_DATE");
            this.Map(x => x.ModifiedDate).Column("MODIFIED_DATE");
        }
    }
}
