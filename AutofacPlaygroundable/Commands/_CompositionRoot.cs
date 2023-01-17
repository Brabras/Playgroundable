using Autofac;
using JetBrains.Annotations;

namespace AutofacPlaygroundable.Commands;

[UsedImplicitly]
internal class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterHandlerDecorator(typeof(ApplicationCommandHandlerDecorator<>));

        builder.RegisterType<CommandHandler>().SingleInstance();
    }
}