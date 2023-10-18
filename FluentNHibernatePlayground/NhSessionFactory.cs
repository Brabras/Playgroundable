using Infrastructure.DataAccess;
using NHibernate;

namespace FluentNHibernatePlayground;

public static class NhSessionFactory
{
    public static ISessionFactory Build()
    {
        return new SessionFactoryBuilder()
               .AddFluentMappingsFrom("FluentNHibernatePlayground")
               .Build();
    }
}