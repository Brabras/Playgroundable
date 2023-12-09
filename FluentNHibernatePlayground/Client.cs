using FluentNHibernate.Data;

namespace FluentNHibernatePlayground;

public class Client : Entity
{
    public IList<Wallet> Wallets { get; set; }
}