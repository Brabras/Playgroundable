namespace AutofacPlaygroundable.DomainEvents;

public interface IDomainEventHandler
{
    Task HandleAsync(DomainEvent.DomainEvent domainEvent, CancellationToken cancellationToken);
}

public abstract class DomainEventHandler<TDomainEvent> : IDomainEventHandler
    where TDomainEvent : DomainEvent.DomainEvent
{
    public Task HandleAsync(DomainEvent.DomainEvent domainEvent, CancellationToken cancellationToken)
    {
        return HandleAsync((TDomainEvent)domainEvent, cancellationToken);
    }

    protected abstract Task HandleAsync(TDomainEvent domainEvent, CancellationToken cancellationToken);
}