using Nest;

namespace DocumentsKeeperDemo.Repositories.Infrastructure.ElasticSearch
{
    /// <summary>
    /// The interface for the ElasticSearch factory.
    /// </summary>
    public interface IElasticClientFactory
    {
        /// <summary>
        /// Creates an ElasticSearch client.
        /// </summary>
        /// <returns>
        /// Returns ElasticSearch client.
        /// </returns>
        IElasticClient CreateElasticClient();
    }
}