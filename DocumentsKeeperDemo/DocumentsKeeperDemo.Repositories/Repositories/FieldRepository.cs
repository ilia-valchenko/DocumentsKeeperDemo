using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using NHibernate;
using NHibernate.Linq;
using DocumentsKeeperDemo.Core.Extensions;
using DocumentsKeeperDemo.Repositories.Extensions;

namespace DocumentsKeeperDemo.Repositories.Repositories
{
    /// <summary>
    /// The field repository.
    /// </summary>
    public class FieldRepository : IFieldRepository
    {
        /// <summary>
        /// The session factory.
        /// </summary>
        private readonly ISessionFactory sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldRepository"/> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public FieldRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public IEnumerable<FieldEntity> GetFields(
            Expression<Func<FieldEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var fields = session.Query<FieldEntity>()
                    .Where(predicate);

                return fields;
            }
        }

        public IEnumerable<FieldLiteEntity> GetLiteFields(
            Expression<Func<FieldLiteEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var liteFields = session.Query<FieldLiteEntity>()
                    .Where(predicate)
                    .ToList();

                return liteFields;
            }
        }

        public FieldEntity GetField(Expression<Func<FieldEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var field = session.Query<FieldEntity>()
                    .FirstOrDefault(predicate);

                return field;
            }
        }

        public FieldEntity CreateField(FieldEntity field)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var id = session.Save(field);
                    transaction.Commit();
                    field.Id = (string)id;

                    return field;
                }
            }
        }

        public void DeleteField(Guid fieldId)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.DeleteById<FieldEntity>(fieldId.ToNonDashedString());
                    transaction.Commit();
                }
            }
        }
    }
}