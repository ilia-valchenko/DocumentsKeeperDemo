using System;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using Nest;
using System.Configuration;

namespace DocumentsKeeperDemo.Repositories.Infrastructure.ElasticSearch
{
    /// <summary>
    /// The ElasticSearch factory.
    /// </summary>
    public class ElasticClientFactory : IElasticClientFactory
    {
        /// <summary>
        /// Creates configured ElasticSearch client.
        /// </summary>
        /// <returns>
        /// Returnes configured ElasticSearch client.
        /// </returns>
        public IElasticClient CreateElasticClient()
        {
            string indexName = ConfigurationManager.AppSettings["elasticSearchIndexName"];
            string elasticSearchUri = ConfigurationManager.AppSettings["elasticSearchUri"];

            ElasticClient client = new ElasticClient(
                new ConnectionSettings(new Uri(elasticSearchUri)));

            if (client.IndexExists(indexName).Exists)
            {
                return client;
            }

            ICreateIndexResponse createIndexResponse = client.CreateIndex(indexName, u => u
                    .Settings(s => s
                        .Analysis(a => a
                            .Tokenizers(token => token
                                .NGram("customNGramTokenizer", ng => ng
                                    .MinGram(1)
                                    .MaxGram(15)
                                    .TokenChars(TokenChar.Letter, TokenChar.Digit)))
                            .Analyzers(analyzer => analyzer
                                .Custom("customIndexNgramAnalyzer", cia => cia
                                    .Filters("lowercase")
                                    .Tokenizer("customNGramTokenizer"))
                                .Custom("customSearchNgramAnalyzer", csa => csa
                                    .Filters("lowercase")
                                    .Tokenizer("keyword")))))
                    .Mappings(map => map
                        .Map<DocumentEntity>(m => m
                            .AutoMap()
                        )
                    )
               );

            return client;
        }
    }
}