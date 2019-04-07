using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using NHibernate;
using NHibernate.Linq;

namespace DocumentsKeeperDemo.Repositories.Repositories
{
    /// <summary>
    /// The field value repository.
    /// </summary>
    public class FieldValueRepository : IFieldValueRepository
    {
        /// <summary>
        /// The session factory.
        /// </summary>
        private readonly ISessionFactory sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValueRepository"/> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public FieldValueRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public FieldValueEntity GetFieldValue(Expression<Func<FieldValueEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var fieldValue = session.Query<FieldValueEntity>()
                    .FirstOrDefault(predicate);

                return fieldValue;
            }
        }

        public IEnumerable<FieldValueEntity> GetFieldValues(
            Expression<Func<FieldValueEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var fieldValues = session.Query<FieldValueEntity>()
                    .Where(predicate)
                    .ToList();

                return fieldValues;
            }
        }

        public FieldValueLiteEntity GetLiteFieldValue(
            Expression<Func<FieldValueLiteEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var liteFieldValue = session.Query<FieldValueLiteEntity>()
                    .FirstOrDefault(predicate);

                return liteFieldValue;
            }
        }

        public IEnumerable<FieldValueLiteEntity> GetLiteFieldValues(
            Expression<Func<FieldValueLiteEntity, bool>> predicate)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                var liteFieldValues = session.Query<FieldValueLiteEntity>()
                    .Where(predicate)
                    .ToList();

                return liteFieldValues;
            }
        }
    }
}