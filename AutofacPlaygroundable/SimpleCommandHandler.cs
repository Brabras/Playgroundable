using AutofacPlaygroundable.Commands;
using AutofacPlaygroundable.DomainEvent;

namespace AutofacPlaygroundable;

public sealed class SimpleCommandHandler : BaseCommandAsyncHandler<SimpleCommand>
{
    public override async Task<CommandHandlerResult> HandleAsync(SimpleCommand command, CancellationToken cancellationToken)
    {
        DomainEventsSession.Raise(new NewMonitoringMatchEvent(4, DateTime.Now));
        Console.WriteLine($"Success {command.Now}");
        return Success();
    }
}