using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DocumentsKeeperDemo.Core.Repositories.Entities;

namespace DocumentsKeeperDemo.Repositories.Interfaces.Repositories
{
    /// <summary>
    /// The folder repository interface.
    /// </summary>
    public interface IFolderRepository
    {
        /// <summary>
        /// Gets folder by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the folder entity.</returns>
        FolderEntity GetFolder(Expression<Func<FolderEntity, bool>> predicate);

        /// <summary>
        /// Gets lite folder by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns the lite folder entity.
        /// </returns>
        FolderLiteEntity GetLiteFolder(Expression<Func<FolderLiteEntity, bool>> predicate);

        /// <summary>
        /// Gets the collection of the folder entities. 
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the collection of folder entities.</returns>
        IEnumerable<FolderEntity> GetFolders(Expression<Func<FolderEntity, bool>> predicate);

        /// <summary>
        /// Gets all folder entities.
        /// </summary>
        /// <returns>
        /// Returns the collection of the folder entities.
        /// </returns>
        IEnumerable<FolderEntity> GetAllFolders();

        /// <summary>
        /// Gets all lite folder entities.
        /// </summary>
        /// <returns>
        /// Returns the collection of folder lite entities.
        /// </returns>
        IEnumerable<FolderLiteEntity> GetAllLiteFolders();

        /// <summary>
        /// Creates a new folder.
        /// </summary>
        /// <param name="folderEntity">The folder entity.</param>
        FolderEntity CreateFolder(FolderEntity folderEntity);

        /// <summary>
        /// Removes folder by id.
        /// </summary>
        /// <param name="folderId">The id of the folder that have to be removed.</param>
        void DeleteFolder(string folderId);
    }
}
