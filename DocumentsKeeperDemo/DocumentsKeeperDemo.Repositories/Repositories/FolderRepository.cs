using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using NHibernate;
using NHibernate.Linq;
using DocumentsKeeperDemo.Repositories.Extensions;
using DocumentsKeeperDemo.Core.Extensions;

namespace DocumentsKeeperDemo.Repositories.Repositories
{
    /// <summary>
    /// The folder repository. 
    /// </summary>
    public sealed class FolderRepository : IFolderRepository
    {
        /// <summary>
        /// The session factory.
        /// </summary>
        private readonly ISessionFactory sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderRepository"/> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public FolderRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Gets the folder entity by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the folder entity.</returns>
        public FolderEntity GetFolder(Expression<Func<FolderEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var folderEntity = session.Query<FolderEntity>().FirstOrDefault(predicate);

                if (folderEntity != null)
                {
                    NHibernateUtil.Initialize(folderEntity.Documents);
                    NHibernateUtil.Initialize(folderEntity.Fields);
                }

                return folderEntity;
            }
        }

        /// <summary>
        /// Gets lite folder entity by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns lite folder entity.
        /// </returns>
        public FolderLiteEntity GetLiteFolder(Expression<Func<FolderLiteEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var folderLiteEntity = session.Query<FolderLiteEntity>()
                    .FirstOrDefault(predicate);

                return folderLiteEntity;
            }
        }

        /// <summary>
        /// Gets the collection of the folder entities by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the collection of the folder entities.</returns>
        public IEnumerable<FolderEntity> GetFolders(
            Expression<Func<FolderEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all folder entities.
        /// </summary>
        /// <returns>
        /// Returns the collection of the folder entities.
        /// </returns>
        public IEnumerable<FolderEntity> GetAllFolders()
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var folderEntities = session.Query<FolderEntity>().ToList();

                foreach (var entity in folderEntities)
                {
                    NHibernateUtil.Initialize(entity.Documents);
                    NHibernateUtil.Initialize(entity.Fields);
                }

                return folderEntities;
            }
        }

        /// <summary>
        /// Gets all lite folder entities.
        /// </summary>
        /// <returns>
        /// Returns the collection of lite folder entities.
        /// </returns>
        public IEnumerable<FolderLiteEntity> GetAllLiteFolders()
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var folderLiteEntities = session.Query<FolderLiteEntity>().ToList();
                return folderLiteEntities;
            }
        }

        /// <summary>
        /// Creates a new folder.
        /// </summary>
        /// <param name="folderEntity">The folder entity.</param>
        public FolderEntity CreateFolder(FolderEntity folderEntity)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = session.Save(folderEntity);

                    foreach (var field in folderEntity.Fields)
                    {
                        session.Save(field);
                    }

                    transaction.Commit();

                    return folderEntity;
                }
            }
        }

        public void DeleteFolder(Guid folderId)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.DeleteById<FolderEntity>(folderId.ToNonDashedString());
                    transaction.Commit();
                }
            }
        }
    }
}