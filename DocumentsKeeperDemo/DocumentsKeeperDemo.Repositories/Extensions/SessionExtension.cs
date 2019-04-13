using NHibernate;

namespace DocumentsKeeperDemo.Repositories.Extensions
{
    public static class SessionExtension
    {
        public static void DeleteById<TEntity>(this ISession session, object id)
        {
            var queryString = string.Format("delete {0} where id = :id",
                                            typeof(TEntity));

            session.CreateQuery(queryString)
                   .SetParameter("id", id)
                   .ExecuteUpdate();
        }
    }
}
