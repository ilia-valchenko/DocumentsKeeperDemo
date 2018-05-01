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
        FolderEntity GetLiteFolder(Expression<Func<FolderEntity, bool>> predicate);

        /// <summary>
        /// Gets the collection of the folder entities. 
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the collection of folder entities.</returns>
        List<FolderEntity> GetFolders(Expression<Func<FolderEntity, bool>> predicate);

        /// <summary>
        /// Gets all folder entities.
        /// </summary>
        /// <returns>
        /// Returns the collection of the folder entities.
        /// </returns>
        List<FolderEntity> GetAllFolders();

        /// <summary>
        /// Gets all lite folder entities.
        /// </summary>
        /// <returns>
        /// Returns the collection of folder lite entities.
        /// </returns>
        List<FolderEntity> GetAllLiteFolders();

        /// <summary>
        /// Inserts new folder.
        /// </summary>
        /// <param name="folderEntity">The folder entity.</param>
        void InsertFolder(FolderEntity folderEntity);
    }
}
