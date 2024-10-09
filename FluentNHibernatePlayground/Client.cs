using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace FluentNHibernatePlayground;

public class Client : Entity
{
    public virtual IList<Wallet> Wallets { get; set; } = null!;
    
    public virtual string? Value { get; set; }
}

public class ClientMap : ClassMap<Client>
{
    public ClientMap()
    {
        Schema("test");

        Table("clients");

        Id(x => x.Id);

        HasMany(x => x.Wallets)
            .Inverse()
            .Cascade.SaveUpdate()
            .Fetch.Select();
        
        Map(x => x.Value);
    }
}