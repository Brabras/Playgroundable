using System.Text.Json.Serialization;

namespace Infrastructure.Seedwork.DataTypes;

public class ErrorResult
{
    public long? Code { get; set; }

    public string? Message { get; set; }

    public Dictionary<string, string>? ParameterErrors { get; private set; }

    public ErrorResult()
    {
    }

    [JsonConstructor]
    public ErrorResult(long? code,
                       string? message,
                       Dictionary<string, string>? parameterErrors)
    {
        Code            = code;
        Message         = message;
        ParameterErrors = parameterErrors;
    }

    public static implicit operator ErrorResult(string error)
    {
        var result = new ErrorResult
        {
            Message         = error
        };
        
        return result;
    }
}