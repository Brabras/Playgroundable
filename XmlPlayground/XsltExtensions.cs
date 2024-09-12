using System.Xml.XPath;
using JetBrains.Annotations;

namespace XmlPlayground;

public class XsltExtensions
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
//
// public class TrimFunction : ExtensionFunctionDefinition
// {
//     public override QName FunctionName => new QName("ext", "urn:ext-scripts", "trim");
//     public override int MinimumNumberOfArguments => 1;
//     public override int MaximumNumberOfArguments => 1;
//
//     public override XdmSequenceType[] ArgumentTypes => new[]
//     {
//         new XdmSequenceType(XdmAtomicType.BuiltInAtomicType(QName.XS_STRING), '?')
//     };
//
//     public override XdmSequenceType ResultType(XdmSequenceType[] argumentTypes) =>
//         new(XdmAtomicType.BuiltInAtomicType(QName.XS_STRING), '?');
//
//     public override ExtensionFunctionCall MakeFunctionCall() => new TrimFunctionCall();
// }
//
// public class TrimFunctionCall : ExtensionFunctionCall
// {
//     public override IEnumerator<XdmItem> Call(IEnumerator<XdmItem>[] arguments, DynamicContext context)
//     {
//         var arg    = arguments[0].MoveNext() ? arguments[0].Current : null;
//         var result = arg?.GetStringValue().Trim();
//
//         return result == null ? XdmEmptySequence.INSTANCE.GetEnumerator() : new XdmAtomicValue(result).GetEnumerator();
//     }
// }
//
// public class FullNameFunction : ExtensionFunctionDefinition
// {
//     public override QName FunctionName => new QName("ext", "urn:ext-scripts", "fullName");
//     public override int MinimumNumberOfArguments => 4;
//     public override int MaximumNumberOfArguments => 4;
//
//     public override XdmSequenceType[] ArgumentTypes => new[]
//     {
//         new XdmSequenceType(XdmAtomicType.BuiltInAtomicType(QName.XS_STRING), '?'),
//         new XdmSequenceType(XdmAtomicType.BuiltInAtomicType(QName.XS_STRING), '?'),
//         new XdmSequenceType(XdmAtomicType.BuiltInAtomicType(QName.XS_STRING), '?'),
//         new XdmSequenceType(XdmAtomicType.BuiltInAtomicType(QName.XS_STRING), '?')
//     };
//
//     public override XdmSequenceType ResultType(XdmSequenceType[] argumentTypes) =>
//         new(XdmAtomicType.BuiltInAtomicType(QName.XS_STRING), '?');
//
//     public override ExtensionFunctionCall MakeFunctionCall() => new FullNameFunctionCall();
// }
//
// public class FullNameFunctionCall : ExtensionFunctionCall
// {
//     public override IEnumerator<XdmItem> Call(IEnumerator<XdmItem>[] arguments, DynamicContext context)
//     {
//         var list = new List<string>();
//
//         for (int i = 0; i < arguments.Length; i++)
//         {
//             if (arguments[i].MoveNext())
//             {
//                 var value = arguments[i].Current.GetStringValue();
//                 if (!string.IsNullOrWhiteSpace(value))
//                 {
//                     list.Add(value.Trim());
//                 }
//             }
//         }
//
//         if (list.Count == 0)
//         {
//             return XdmEmptySequence.INSTANCE.GetEnumerator();
//         }
//
//         var result = string.Join(" ", list).Trim();
//         return new XdmAtomicValue(result).GetEnumerator();
//     }
// }
//
// public class ConcatFunction : ExtensionFunctionDefinition
// {
//     public override QName FunctionName => new QName("ext", "urn:ext-scripts", "concat");
//     public override int MinimumNumberOfArguments => 2;
//     public override int MaximumNumberOfArguments => 2;
//
//     public override XdmSequenceType[] ArgumentTypes => new[]
//     {
//         new XdmSequenceType(XdmAtomicType.BuiltInAtomicType(QName.XS_STRING), ' '),
//         new XdmSequenceType(XdmAnyItemType.Instance, '+')
//     };
//
//     public override XdmSequenceType ResultType(XdmSequenceType[] argumentTypes) => new(XdmAtomicType.BuiltInAtomicType(QName.XS_STRING), ' ');
//
//     public override ExtensionFunctionCall MakeFunctionCall() => new ConcatFunctionCall();
// }
//
// public class ConcatFunctionCall : ExtensionFunctionCall
// {
//     public override IEnumerator<XdmItem> Call(IEnumerator<XdmItem>[] arguments, DynamicContext context)
//     {
//         var separator = arguments[0].MoveNext() ? arguments[0].Current.GetStringValue() : null;
//
//         var nodes = arguments[1];
//
//         var values = new List<string>();
//         while (nodes.MoveNext())
//         {
//             values.Add(nodes.Current.GetStringValue().Trim());
//         }
//
//         var result = string.Join(separator, values);
//         return new XdmAtomicValue(result).GetEnumerator();
//     }
// }