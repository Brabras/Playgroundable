using System.Xml.XPath;
using JetBrains.Annotations;

namespace XmlPlayground.Content;

public class CollectorExtensions
{
    public const string Namespace = "urn:ext-scripts";

    [UsedImplicitly]
    public string? Trim(string? str)
    {
        return str?.Trim();
    }

    [UsedImplicitly]
    public string? FullName(string? a,
                            string? b,
                            string? c,
                            string? d)
    {
        var list = new List<string>();

        if (!string.IsNullOrWhiteSpace(a))
            list.Add(a.Trim());

        if (!string.IsNullOrWhiteSpace(b))
            list.Add(b.Trim());

        if (!string.IsNullOrWhiteSpace(c))
            list.Add(c.Trim());

        if (!string.IsNullOrWhiteSpace(d))
            list.Add(d.Trim());

        if (list.Count == 0)
            return null;

        return string.Join(" ", list).Trim();
    }
    
    [UsedImplicitly]
    public string Concat(string separator, XPathNodeIterator xPathNodeIterator)
    {
        var trimmed = new List<string>();

        while (xPathNodeIterator.MoveNext())
        {
            var xPathNavigator = xPathNodeIterator.Current;
            if (xPathNavigator is null)
                continue;
            
            trimmed.Add(xPathNavigator.Value.Trim());
        }
        
        return string.Join(separator, trimmed);
    }
}