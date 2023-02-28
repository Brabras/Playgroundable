using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;

namespace LoggingPlayground;

public sealed class LoggerBuilder
{
    private string? _applicationName;

    public LoggerBuilder WithApplicationName(string applicationName)
    {
        _applicationName = applicationName;
        return this;
    }
    
    public ILogger Build(IConfiguration configuration)
    {
        if (_applicationName is null)
            throw new InvalidOperationException("Application name is not defined");
        
        var loggerConfiguration = new LoggerConfiguration()
            .Enrich.WithProperty("Application", _applicationName)
            .Enrich.WithExceptionDetails()
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(configuration);

        return loggerConfiguration.CreateLogger();
    }
}