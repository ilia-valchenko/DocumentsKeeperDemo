using DocumentsKeeperDemo.Core.Repositories.Entities;
using FluentNHibernate.Mapping;

namespace DocumentsKeeperDemo.Repositories.NHibernateMaps
{
	/// <summary>
	/// The document entity map.
	/// </summary>
	public sealed class DocumentEntityMap : ClassMap<DocumentEntity>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentEntityMap"/> class.
		/// </summary>
		public DocumentEntityMap()
		{
			this.Table("DOCUMENTS");

			this.Id(x => x.Id).Column("DOCUMENT_GUID");

			this.Map(x => x.DocumentNumber).Column("DOCUMENT_NUMBER");
            this.Map(x => x.FileName).Column("FILENAME");
			this.Map(x => x.FileType).Column("FILE_TYPE");
			this.Map(x => x.CreatedDate).Column("CREATED_DATE");
			this.Map(x => x.TextNasPath).Column("TEXT_NAS_PATH");
			this.Map(x => x.FileSize).Column("FILE_SIZE");
			this.Map(x => x.FamilyId).Column("FAMILY_ID");
			this.Map(x => x.UploadId).Column("UPLOAD_ID");

		    this.HasMany(x => x.FieldValues)
		        .Table("FIELD_VALUES")
		        .KeyColumn("DOCUMENT_GUID")
		        .Not.LazyLoad();
		}
	}
}