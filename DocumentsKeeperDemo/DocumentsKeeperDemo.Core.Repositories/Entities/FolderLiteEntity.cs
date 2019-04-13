using System;

namespace DocumentsKeeperDemo.Core.Repositories.Entities
{
    /// <summary>
    /// The folder lite entity that contains general information about the folder.
    /// </summary>
    public class FolderLiteEntity : BaseDatabaseEntity
    {
        /// <summary>
        /// The name of the folder.
        /// </summary>
        public virtual string Name { get; set; }
    }
}