using Autofac;

namespace AutofacPlaygroundable.DomainEvents;

public static class DomainEventHandlerAutofacExtensions
{
    public static void RegisterDomainEvent<TDomainEvent, TDomainEventHandler>(this ContainerBuilder serviceRegistry)
        where TDomainEvent : DomainEvent.DomainEvent
        where TDomainEventHandler : DomainEventHandler<TDomainEvent>
    {
        serviceRegistry.RegisterType<TDomainEventHandler>()
                       .Keyed<IDomainEventHandler>(typeof(TDomainEvent))
                       .SingleInstance();
    }
}