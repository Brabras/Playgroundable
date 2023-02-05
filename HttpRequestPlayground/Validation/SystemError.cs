using System.Text;
using System.Text.Json.Serialization;

namespace ConsolePlaygrouns.Validation;

public sealed class SystemError
{
    public string Message { get; set; } = null!;

    public IDictionary<string, string>? ParameterErrors { get; private set; }

    public static readonly SystemError InternalServerError = new("Внутренняя ошибка системы");
    
    public static readonly SystemError FillField = new("Заполните поле");
    public static readonly SystemError WrongFormat = new("Неверный формат");

    [JsonConstructor]
    public SystemError()
    {
    }

    public SystemError(string message)
    {
        Message = message;
    }

    public SystemError(string message, IDictionary<string, string> parameterErrors)
    {
        Message         = message;
        ParameterErrors = parameterErrors;
    }

    public void SetError(string parameterName, string errorMessage)
    {
        ParameterErrors ??= new Dictionary<string, string>();

        ParameterErrors[parameterName] = errorMessage;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Сообщение: {Message}");

        if (ParameterErrors is not null)
        {
            sb.Append("; Параметры: {");
            var addComma = false;
            foreach (var (key, value) in ParameterErrors)
            {
                if (addComma)
                    sb.Append(", ");

                sb.Append($"'{key}': '{value}'");

                addComma = true;
            }

            sb.Append('}');

            return sb.ToString();
        }

        return string.Empty;
    }
}