using Autofac;
using AutofacPlaygroundable.Commands;
using AutofacPlaygroundable.DomainEvents;

namespace AutofacPlaygroundable;

public class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TodayWriter>().As<IDateWriter>().AsSelf().SingleInstance();

        builder.RegisterDomainEvent<NewMonitoringMatchEvent, NewMonitoringMatchEventHandler>();
        builder.RegisterHandler<SimpleCommand, SimpleCommandHandler>();
    }
}
