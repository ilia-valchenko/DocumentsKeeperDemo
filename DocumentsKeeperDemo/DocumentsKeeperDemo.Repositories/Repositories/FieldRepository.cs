using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using NHibernate;
using NHibernate.Linq;

namespace DocumentsKeeperDemo.Repositories.Repositories
{
    public class FieldRepository : IFieldRepository
    {
        /// <summary>
        /// The session factory.
        /// </summary>
        private readonly ISessionFactory sessionFactory;

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
    }
}
