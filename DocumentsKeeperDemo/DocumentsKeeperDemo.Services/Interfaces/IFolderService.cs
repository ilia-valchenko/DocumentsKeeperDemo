using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Services.Models;

namespace DocumentsKeeperDemo.Services.Interfaces
{
    /// <summary>
    /// The folder interface.
    /// </summary>
    public interface IFolderService
    {
        /// <summary>
        /// Gets folder model by id. 
        /// </summary>
        /// <param name="folderId">The folder id.</param>
        /// <returns>
        /// Returns the folder model.
        /// </returns>
        FolderModel GetFolder(Guid folderId);

        /// <summary>
        /// Gets lite folder model by id.
        /// </summary>
        /// <param name="folderId">The folder id.</param>
        /// <returns>
        /// Returns folder lite model.
        /// </returns>
        FolderModel GetLiteFolder(Guid folderId);

        /// <summary>
        /// Gets all folder models.
        /// </summary>
        /// <returns>
        /// Returns the collection of the folder models.
        /// </returns>
        IEnumerable<FolderModel> GetAllFolders();

        /// <summary>
        /// Gets all lite folder models.
        /// </summary>
        /// <returns>
        /// Returns the collection of folder lite models.
        /// </returns>
        IEnumerable<FolderModel> GetAllLiteFolders();

        /// <summary>
        /// Creates folder.
        /// </summary>
        /// <param name="createFolderModel">The create folder model.</param>
        void CreateFolder(CreateFolderModel createFolderModel);
    }
}
