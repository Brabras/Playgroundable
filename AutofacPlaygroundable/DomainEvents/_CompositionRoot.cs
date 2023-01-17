using Autofac;
using JetBrains.Annotations;

namespace AutofacPlaygroundable.DomainEvents;

[UsedImplicitly]
internal sealed class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DomainEventsHandler>().SingleInstance();
    }
}