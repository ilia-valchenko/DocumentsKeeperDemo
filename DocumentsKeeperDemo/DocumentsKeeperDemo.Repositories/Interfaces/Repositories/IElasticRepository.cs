﻿using DocumentsKeeperDemo.Core.Repositories.Entities;
using System.Collections.Generic;

namespace DocumentsKeeperDemo.Repositories.Interfaces.Repositories
{
    /// <summary>
    /// The interface for the ElasticSearch repository.
    /// </summary>
    public interface IElasticRepository
    {
        /// <summary>
        /// Creates a new document in the provided ElasticSearch index.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="indexName">The name of the index.</param>
        void Create(DocumentEntity document, string indexName);

        /// <summary>
        /// Gets the document by document id.
        /// </summary>
        /// <param name="id">The id of the document.</param>
        /// <param name="indexName">The name of the ElasticSearch index.</param>
        DocumentEntity GetById(int id, string indexName);

        /// <summary>
        /// Gets all the documents that are stored in provided index.
        /// </summary>
        /// <param name="indexName">The name of the index.</param>
        IEnumerable<DocumentEntity> GetAll(string indexName);

        /// <summary>
        /// Gets a collection of the documents that meet required query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="indexName">The name of the index.</param>
        IEnumerable<DocumentEntity> GetQueryResults(string query, string indexName);

        /// <summary>
        /// Update the document in ElasticSearch index.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="indexName">The name of the index.</param>
        void Update(DocumentEntity document, string indexName);

        /// <summary>
        /// Deletes document from ElasticSearch index by using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the document.</param>
        /// <param name="indexName">The name of the index.</param>
        void Delete(int id, string indexName);
    }
}