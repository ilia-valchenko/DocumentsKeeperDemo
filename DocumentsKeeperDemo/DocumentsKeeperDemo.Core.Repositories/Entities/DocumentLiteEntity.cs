using System;

namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
    /// <summary>
    /// The document lite entity that contains general information about the document.
    /// </summary>
    public class DocumentLiteEntity : BaseDatabaseEntity
    {
        /// <summary>
        /// The document number.
        /// </summary>
        public virtual int DocumentNumber { get; set; }

        /// <summary>
        /// The document file type.
        /// </summary>
        public virtual string FileType { get; set; }

        /// <summary>
        /// The created date.
        /// </summary>
        public virtual DateTime CreatedDate { get; set; }

        /// <summary>
        /// The id of the folder.
        /// </summary>
        public virtual string FolderId { get; set; }

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
    }
}
