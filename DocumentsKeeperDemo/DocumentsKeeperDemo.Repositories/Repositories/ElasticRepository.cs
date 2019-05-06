using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using Nest;

namespace DocumentsKeeperDemo.Repositories.Repositories
{
    /// <summary>
    /// The ElasticSearch repository.
    /// </summary>
    public sealed class ElasticRepository : IElasticRepository
    {
        private readonly IElasticClient elasticClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticRepository"/> class.
        /// </summary>
        /// <param name="elasticClient">The ElasticSearch client.</param>
        public ElasticRepository(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        /// <summary>
        /// Creates a new document in the provided ElasticSearch index.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="indexName">The name of the index.</param>
        public void Create(DocumentEntity document, string indexName)
        {
            IIndexResponse indexResponse = elasticClient
                .Index(document, i => i.Index(indexName));
        }

        /// <summary>
        /// Gets all the documents that are stored in provided index.
        /// </summary>
        /// <param name="indexName">The name of the index.</param>
        public IEnumerable<DocumentEntity> GetAll(string indexName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the document by document id.
        /// </summary>
        /// <param name="id">The id of the document.</param>
        /// <param name="indexName">The name of the ElasticSearch index.</param>
        public DocumentEntity GetById(int id, string indexName)
        {
            throw new NotImplementedException();
        }
    }
}