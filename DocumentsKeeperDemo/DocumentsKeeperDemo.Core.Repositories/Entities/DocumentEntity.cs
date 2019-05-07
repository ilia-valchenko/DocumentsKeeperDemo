using System.Collections.Generic;
using Nest;

namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
    /// <summary>
    /// The document entity.
    /// </summary>
    [ElasticsearchType(IdProperty = "Id", Name = "document")]
    public class DocumentEntity : BaseDatabaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentEntity"/> class.
        /// </summary>
        public DocumentEntity()
        {
            this.FieldValues = new List<FieldValueLiteEntity>();
        }

        /// <summary>
        /// The document number.
        /// </summary>
        public virtual int? DocumentNumber { get; set; }

        /// <summary>
        /// The name of the file.
        /// </summary>
        [String(Name = "FileName")]
        public virtual string FileName { get; set; }

        /// <summary>
        /// The document file type.
        /// </summary>
        [String(Name = "FileType")]
        public virtual string FileType { get; set; }

        /// <summary>
        /// The identifier of the folder the document belongs to.
        /// </summary>
        [String(Name = "FolderId")]
        public virtual string FolderId { get; set; }

        /// <summary>
        /// The folder entity.
        /// </summary>
        public virtual FolderLiteEntity Folder { get; set; }

        /// <summary>
        /// The collection of the field value entities.
        /// </summary>
        public virtual IList<FieldValueLiteEntity> FieldValues { get; set; }

        /// <summary>
        /// The text Nas path.
        /// </summary>
        public virtual string TextNasPath { get; set; }

        /// <summary>
        /// The file size.
        /// </summary>
        public virtual long FileSize { get; set; }

        /// <summary>
        /// The document family identifier.
        /// </summary>
        public virtual int FamilyId { get; set; }

        /// <summary>
        /// The upload identifier.
        /// </summary>
        public virtual int UploadId { get; set; }

        /// <summary>
        /// The content of the document.
        /// </summary>
        [String(Name = "DocumentText")]
        public virtual string DocumentText { get; set; }
    }
}