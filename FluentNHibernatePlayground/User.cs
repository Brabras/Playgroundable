namespace FluentNHibernatePlayground;

public class User
{
    public virtual long Id { get; set; }

    // ключ - Merchantd
    public virtual IDictionary<long, IList<Wallet>> Wallets { get; set; } = null!;
}

public class Wallet
{
    public virtual long Id { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual long MerchantId { get; set; }

    public virtual string Account { get; set; } = null!;
}