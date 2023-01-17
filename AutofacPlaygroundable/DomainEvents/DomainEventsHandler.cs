using Autofac;
using AutofacPlaygroundable.DomainEvent;

namespace AutofacPlaygroundable.DomainEvents;

public class DomainEventsHandler
{
    private readonly ILifetimeScope _lifetimeScope;

    public DomainEventsHandler(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }

    public async Task HandleAsync(DomainEventsSession session, CancellationToken cancellationToken)
    {
        foreach (var domainEvent in session.Events)
        {
            try
            {
                var domainEventHandler = _lifetimeScope.ResolveKeyed<IDomainEventHandler>(domainEvent.GetType());

                await domainEventHandler.HandleAsync(domainEvent, cancellationToken);
            }
            catch (Exception ex)
            {
            }
        }
    }
}