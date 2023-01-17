using System.Diagnostics;
using AutofacPlaygroundable.DomainEvent;
using AutofacPlaygroundable.DomainEvents;

namespace AutofacPlaygroundable.Commands;

public sealed class ApplicationCommandHandlerDecoratorAttribute : CommandHandlerDecoratorAttribute
{
    public ApplicationCommandHandlerDecoratorAttribute()
        : base(typeof(ApplicationCommandHandlerDecorator<>))
    {
    }
}

internal sealed class ApplicationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
{
    private readonly ICommandHandler<TCommand> _next;
    private readonly DomainEventsHandler _domainEventsHandler;

    public ApplicationCommandHandlerDecorator(ICommandHandler<TCommand> next,
                                              DomainEventsHandler domainEventsHandler)
    {
        _next                = next;
        _domainEventsHandler = domainEventsHandler;
    }

    public async Task<CommandHandlerResult> HandleAsync(TCommand command, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();

        using var domainEventsSession = DomainEventsSession.Bind();
        
        var result = await _next.HandleAsync(command, cancellationToken);

        if (result.IsFailure)
        {

        }
        else
        {
            await _domainEventsHandler.HandleAsync(domainEventsSession, cancellationToken);
        }

        stopwatch.Stop();
        
        return result;
    }
}