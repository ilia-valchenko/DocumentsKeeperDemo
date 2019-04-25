using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using DocumentsKeeperDemo.Repositories.Extensions;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace DocumentsKeeperDemo.Repositories.Repositories
{
    /// <summary>
    /// The document repository.
    /// </summary>
    public class DocumentRepository : IDocumentRepository
    {
        /// <summary>
        /// The session factory.
        /// </summary>
        private readonly ISessionFactory sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentRepository"/> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public DocumentRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Get all document entities.
        /// </summary>
        /// <returns>
        /// Returns the collection of the document entities.
        /// </returns>
        public IEnumerable<DocumentEntity> GetAllDocumentEntities()
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var documentEntities = session.Query<DocumentEntity>().ToList();

                foreach (var entity in documentEntities)
                {
                    NHibernateUtil.Initialize(entity.Folder);
                    NHibernateUtil.Initialize(entity.FieldValues);
                }

                return documentEntities;
            }
        }

        /// <summary>
        /// Gets all document lite entities.
        /// </summary>
        /// <returns>
        /// Returns the collection of document lite entities.
        /// </returns>
        public IEnumerable<DocumentLiteEntity> GetAllDocumentLiteEntities()
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var documentLiteEntities = session.Query<DocumentLiteEntity>().ToList();
                return documentLiteEntities;
            }
        }

        /// <summary>
        /// Gets the instance of the <see cref="DocumentEntity"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns the instance of the <see cref="DocumentEntity"/> class.
        /// </returns>
        public DocumentEntity GetDocumentEntity(Expression<Func<DocumentEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var documentEntity = session.Query<DocumentEntity>()
                    .FirstOrDefault(predicate);

                //if (documentEntity != null)
                //{
                //    NHibernateUtil.Initialize(documentEntity.Folder);
                //    NHibernateUtil.Initialize(documentEntity.FieldValues);
                //}

                return documentEntity;
            }
        }

        /// <summary>
        /// Gets document lite entity by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns document lite entity.
        /// </returns>
        public DocumentLiteEntity GetDocumentLiteEntity(
            Expression<Func<DocumentLiteEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var documentLiteEntity = session.Query<DocumentLiteEntity>()
                    .FirstOrDefault(predicate);

                return documentLiteEntity;
            }
        }

        /// <summary>
        /// Gets the collection of instances of the <see cref="DocumentEntity"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// The collection of instances of the <see cref="DocumentEntity"/> class.
        /// </returns>
        public IEnumerable<DocumentEntity> GetDocumentEntities(
            Expression<Func<DocumentEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var documentEntities = session.Query<DocumentEntity>()
                    .Where(predicate).ToList();

                foreach (var entity in documentEntities)
                {
                    NHibernateUtil.Initialize(entity.Folder);
                    NHibernateUtil.Initialize(entity.FieldValues);
                }

                return documentEntities;
            }
        }

        public IEnumerable<DocumentEntity> InsertDocuments(IEnumerable<DocumentEntity> documents)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    foreach (var document in documents)
                    {
                        var result = session.Save(document);
                    }

                    transaction.Commit();
                }
            }

            return documents;
        }

        public IEnumerable<DocumentLiteEntity> GetDocumentLiteEntities(
            Expression<Func<DocumentLiteEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var documentLiteEntities = session.Query<DocumentLiteEntity>()
                    .Where(predicate)
                    .ToList();

                return documentLiteEntities;
            }
        }

        /// <summary>
        /// Removes document by document id.
        /// </summary>
        public void DeleteDocument(string documentId)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.DeleteById<DocumentEntity>(documentId);
                    transaction.Commit();
                }
            }
        }
    }
}