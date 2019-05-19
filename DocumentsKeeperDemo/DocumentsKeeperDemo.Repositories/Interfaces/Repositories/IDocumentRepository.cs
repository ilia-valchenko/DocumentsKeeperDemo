using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DocumentsKeeperDemo.Core.Repositories.Entities;

namespace DocumentsKeeperDemo.Repositories.Interfaces.Repositories
{
    /// <summary>
    /// The document repository.
    /// </summary>
    public interface IDocumentRepository
    {
        /// <summary>
        /// Gets all document entities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<DocumentEntity> GetAllDocumentEntities();

        /// <summary>
        /// Gets all document lite entities.
        /// </summary>
        /// <returns>
        /// Returns the collection of document lite entities.
        /// </returns>
        IEnumerable<DocumentLiteEntity> GetAllDocumentLiteEntities();

        /// <summary>
        /// Gets the instance of the <see cref="DocumentEntity"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns the instance of the <see cref="DocumentEntity"/> class.
        /// </returns>
        DocumentEntity GetDocumentEntity(Expression<Func<DocumentEntity, bool>> predicate);

        /// <summary>
        /// Gets document lite entity by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns document lite entity.
        /// </returns>
        DocumentLiteEntity GetDocumentLiteEntity(
            Expression<Func<DocumentLiteEntity, bool>> predicate);

        /// <summary>
        /// Gets the collection of instances of the <see cref="DocumentEntity"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="startFrom">The number of the first element
        /// that have to be fetched.</param>
        /// <param name="limit">The limit value.</param>
        /// <returns>
        /// The collection of instances of the <see cref="DocumentEntity"/> class.
        /// </returns>
        IEnumerable<DocumentEntity> GetDocumentEntities(
            Expression<Func<DocumentEntity, bool>> predicate,
            int startFrom,
            int limit);

        /// <summary>
        /// Inserts documents.
        /// </summary>
        /// <param name="documents">The collection of documents that
        /// have to be inserted.</param>
        IEnumerable<DocumentEntity> InsertDocuments(IEnumerable<DocumentEntity> documents);

        /// <summary>
        /// Gets the collection of the document lite entities by using the predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="startFrom">The number of the first element
        /// that have to be fetched.</param>
        /// <param name="limit">The limit value.</param>
        IEnumerable<DocumentLiteEntity> GetDocumentLiteEntities(
            Expression<Func<DocumentLiteEntity, bool>> predicate,
            int startFrom,
            int limit);

        /// <summary>
        /// Removes document by document id.
        /// </summary>
        /// <param name="documentId">The id of the document that have to be removed.</param>
        void DeleteDocument(string documentId);

        /// <summary>
        /// Gets the number of the documents that are contained
        /// in the provided folder.
        /// </summary>
        /// <param name="folderId">The id of the folder.</param>
        /// <returns>Returns the number of the document.</returns>
        int GetDocumentsCount(string folderId);
    }
}