namespace AutofacPlaygroundable.Commands;

public class CommandHandlerResult
{
    public static readonly CommandHandlerResult Unit = new(value: new object(), error: null);

    public bool IsFailure => _error is not null;

    private readonly object? _error;
    public object Error => _error ?? throw new InvalidOperationException("Cannot get error, result is in success state");

    private readonly object? _value;
    public object Value => _value ?? throw new InvalidOperationException("Cannot get value, result is in error state");

    private CommandHandlerResult(object? value, object? error)
    {
        _value = value;
        _error = error;
    }

    public static CommandHandlerResult Success(object result)
    {
        return new CommandHandlerResult(result, error: null);
    }

    public static CommandHandlerResult Failure(object error)
    {
        return new CommandHandlerResult(value: null, error: error);
    }
}