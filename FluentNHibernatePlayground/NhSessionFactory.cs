using Infrastructure.DataAccess;
using NHibernate;

namespace FluentNHibernatePlayground;

public static class NhSessionFactory
{
    public static ISessionFactory Build()
    {
        return new SessionFactoryBuilder()
               .AddFluentMappingsFrom("FluentNHibernatePlayground")
               // .ExposeConfiguration(cfg =>
               //                      {
               //
               //                          cfg.SetListener(ListenerType.Load, new CustomEventListener());
               //                      }
               //                          
               //                          // cfg.SetInterceptor(new CustomInterceptor())
               //                          )
               .Build();
    }
}