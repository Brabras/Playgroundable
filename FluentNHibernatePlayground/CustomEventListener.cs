using System.Text.Json;
using NHibernate.Event;

namespace FluentNHibernatePlayground;

public class CustomEventListener : IPostLoadEventListener
{
    public void OnPostLoad(PostLoadEvent theEvent)
    {
        var entity = theEvent.Entity;

        var serializedEventResult = JsonSerializer.Serialize(nameof(theEvent.Persister));
        Console.WriteLine(serializedEventResult);
        var serializedEntity = JsonSerializer.Serialize(entity);
        Console.WriteLine(serializedEntity);
        Wallet wallet = (Wallet)theEvent.Entity;
        wallet.Value += 1;
    }
}