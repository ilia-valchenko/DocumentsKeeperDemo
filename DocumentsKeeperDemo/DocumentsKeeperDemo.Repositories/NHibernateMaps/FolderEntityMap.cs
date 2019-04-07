using DocumentsKeeperDemo.Core.Repositories.Entities;
using FluentNHibernate.Mapping;

namespace DocumentsKeeperDemo.Repositories.NHibernateMaps
{
	/// <summary>
	/// The folder entity map.
	/// </summary>
	public sealed class FolderEntityMap : ClassMap<FolderEntity>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FolderEntityMap"/> class.
		/// </summary>
		public FolderEntityMap()
		{
			this.Table("FOLDERS");

			this.Id(x => x.Id).Column("FOLDER_GUID");
			this.Map(x => x.Name).Column("NAME");
			this.Map(x => x.CreatedDate).Column("CREATED_DATE");
			this.Map(x => x.LastModified).Column("MODIFIED_DATE");

		    this.HasMany(x => x.Documents)
		        .Table("DOCUMENTS")
		        .KeyColumn("FOLDER_GUID");

		    this.HasMany(x => x.Fields)
		        .Table("FIELDS")
		        .KeyColumn("FOLDER_GUID");
		}
	}
}
