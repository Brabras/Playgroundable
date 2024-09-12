using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace FluentNHibernatePlayground;

public class Wallet : Entity
{
    public virtual Client Client { get; set; } = null!;
    
    public virtual string? Value { get; set; }
}

public class WalletMap : ClassMap<Wallet>
{
    public WalletMap()
    {
        Schema("test");
        
        Table("wallets");

        Id(x => x.Id);

        References(x => x.Client);
        
        Map(x => x.Value);
    }
}