using System.Text.RegularExpressions;

namespace FluentNHibernatePlayground;

public class MonitoringListTransformReplacement
{
    private const RegexOptions Options = RegexOptions.Multiline | RegexOptions.Compiled;
    
    public string Pattern { get; protected set; } = null!;

    public string Value { get; protected set; } = null!;

    private Regex? _regexPattern;

    protected MonitoringListTransformReplacement()
    {
    }

    public string Replace(string xml)
    {
        var regex = GetRegex();

        regex.Replace(xml, Value);
        
        return xml;
    }

    private Regex GetRegex()
    {
        return _regexPattern ??= new Regex(Pattern, Options);
    }
    
    public static MonitoringListTransformReplacement Create(string pattern,
                                                            string value)
    {
        return new MonitoringListTransformReplacement
        {
            _regexPattern = new Regex(pattern, Options),
            Pattern       = pattern,
            Value         = value
        };
    }
}