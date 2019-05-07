using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using System.Collections.Generic;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using Nest;
using System.Linq;

namespace DocumentsKeeperDemo.Repositories.Repositories
{
    /// <summary>
    /// The ElasticSearch repository.
    /// </summary>
    public sealed class ElasticRepository : IElasticRepository
    {
        private readonly IElasticClient elasticClient;
        private const string nameOfHighlightedField = "DocumentText";

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
        /// Gets the document by document id.
        /// </summary>
        /// <param name="id">The id of the document.</param>
        /// <param name="indexName">The name of the ElasticSearch index.</param>
        public DocumentEntity GetById(int id, string indexName)
        {
            var response = elasticClient.Get<DocumentEntity>(id, i => i.Index(indexName));
            return response.Source;
        }

        /// <summary>
        /// Gets all the documents that are stored in provided index.
        /// </summary>
        /// <param name="indexName">The name of the index.</param>
        public IEnumerable<DocumentEntity> GetAll(string indexName)
        {
            var response = elasticClient.Search<DocumentEntity>(i => i.Index(indexName));
            return response.Documents;
        }

        /// <summary>
        /// Gets a collection of the documents that meet required query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="indexName">The name of the index.</param>
        public IEnumerable<DocumentEntity> GetQueryResults(string query, string indexName)
        {
            var response =
                elasticClient.Search<DocumentEntity>(s => s
                .Index(indexName)
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f.DocumentText)
                            .Query(query)
                        )
                    )
                    .Highlight(h => h
                        .Fields(fs => fs
                            .Field(fl => fl.DocumentText)
                        )
                    )
                );

            // Add new entity for displaying document texts with highlights.
           var searchResults = response.Documents;
            IReadOnlyCollection<IHit<DocumentEntity>> hits = response.Hits;

            for (int i = 0; i < hits.Count; i++)
            {
                var highlights = hits.ElementAt(i).Highlights;
                var highlightedTextTitle = highlights[nameOfHighlightedField]
                    .Highlights.ElementAt(0);
                searchResults.ElementAt(i).DocumentText = highlightedTextTitle;
            }

            return searchResults;
        }

        /// <summary>
        /// Update the document in ElasticSearch index.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="indexName">The name of the index.</param>
        public void Update(DocumentEntity document, string indexName)
        {
            var response = elasticClient
                .Update<DocumentEntity>(document.Id, i => i.Index(indexName).Doc(document));
        }

        /// <summary>
        /// Deletes document from ElasticSearch index by using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the document.</param>
        /// <param name="indexName">The name of the index.</param>
        public void Delete(int id, string indexName)
        {
            var response = elasticClient.Delete<DocumentEntity>(id, i => i.Index(indexName));
        }
    }
}