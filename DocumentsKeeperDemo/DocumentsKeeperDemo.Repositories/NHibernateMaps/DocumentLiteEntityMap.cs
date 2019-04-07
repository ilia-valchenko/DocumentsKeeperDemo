using DocumentsKeeperDemo.Core.Repositories.Entities;
using FluentNHibernate.Mapping;

namespace DocumentsKeeperDemo.Repositories.NHibernateMaps
{
    /// <summary>
    /// The document lite entity map.
    /// </summary>
    public class DocumentLiteEntityMap : ClassMap<DocumentLiteEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentLiteEntityMap"/> class.
        /// </summary>
        public DocumentLiteEntityMap()
        {
            this.Table("DOCUMENTS");

            this.Id(x => x.Id).Column("DOCUMENT_GUID");

            this.Map(x => x.FolderId).Column("FOLDER_GUID");
            this.Map(x => x.DocumentNumber).Column("DOCUMENT_NUMBER");
            this.Map(x => x.FileType).Column("FILE_TYPE");
            this.Map(x => x.CreatedDate).Column("CREATED_DATE");
            this.Map(x => x.TextNasPath).Column("TEXT_NAS_PATH");
            this.Map(x => x.FileSize).Column("FILE_SIZE");
            this.Map(x => x.FamilyId).Column("FAMILY_ID");
            this.Map(x => x.UploadId).Column("UPLOAD_ID");
        }
    }
}
