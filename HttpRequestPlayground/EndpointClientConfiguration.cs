namespace ConsolePlaygrouns;

public sealed class EndpointClientConfiguration
{
    public string BaseUri { get; init; } = null!;

    public string UserName { get; init; } = null!;

    public string Password { get; init; } = null!;

    public TimeSpan Timeout { get; init; }
}