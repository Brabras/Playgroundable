using System.Runtime;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace Asp.NetPlayground;

public class Worker : BackgroundService
{
    const string EufsPath = "Content/31.07.24_EUFS.xml";
    const string OfacPath = "Content/31.07.24_OFAC.xml";
    const string UnPath = "Content/31.07.24_UN.xml";

    const string EufsTransformPath = "Content/EUFSTransform.xslt";
    const string OfacTransformPath = "Content/OFACTransform.xslt";
    const string UnTransformPath = "Content/UNTransform.xslt";

    private static readonly Dictionary<string, string> Dict = new()
    {
        { EufsPath, EufsTransformPath },
        { OfacPath, OfacTransformPath },
        { UnPath, UnTransformPath }
    };

    private readonly Dictionary<string, string> _xsltXmls = new();

    private static readonly XsltArgumentList XsltArgumentList = new();
    private static readonly XsltSettings XsltSettings = new() { EnableScript            = true };
    private static readonly XmlReaderSettings XmlReaderSettings = new() { DtdProcessing = DtdProcessing.Parse };

    // private static readonly Dictionary<string, XslCompiledTransform> Transforms = new();

    public Worker()
    {
        XsltArgumentList.AddExtensionObject(XsltExtensions.Namespace, new XsltExtensions());
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        foreach (var keyValue in Dict)
        {
            var xmlString  = File.ReadAllText(Path.Combine(".", keyValue.Key));
            var xsltString = File.ReadAllText(Path.Combine(".", keyValue.Value));

            _xsltXmls.Add(xsltString, xmlString);
        }

        Console.WriteLine("Make first snapshot: files read");
        Console.ReadLine();
        var cycleIncrement = 1;

        while (true)
        {
            foreach (var keyValue in _xsltXmls)
            {
                TransformPayload(keyValue.Key, keyValue.Value);
            }

            Console.WriteLine($"Make next snapshot: all xmls transformed, cycle {cycleIncrement}");
            Console.ReadLine();
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();

            Console.WriteLine($"Make next snapshot: garbage collected, cycle {cycleIncrement}");
            Console.ReadLine();
            ++cycleIncrement;

            if (DateTime.Now == new DateTime())
                break;
        }

        return Task.CompletedTask;
    }

    private static void TransformPayload(string xslt, string xml)
    {
        var getTransformResult = GetXsltCompiledTransform(xslt);
        // var getTransformResult = GetCachedXsltCompiledTransform(xslt);


        using var xmlReader = XmlReader.Create(new StringReader(xml), XmlReaderSettings);
        using var xmlWriter = new StringWriter();
        getTransformResult.Transform(xmlReader, XsltArgumentList, xmlWriter);
    }

    private static XslCompiledTransform GetXsltCompiledTransform(string xslt)
    {
        var xsltByteArr = Encoding.UTF8.GetBytes(xslt);

        using var xsltStream   = new MemoryStream(xsltByteArr);
        using var xsltReader   = XmlReader.Create(xsltStream);
        var       newTransform = new XslCompiledTransform();
        newTransform.Load(xsltReader, XsltSettings, null);

        return newTransform;
    }
    //
    // private static XslCompiledTransform GetCachedXsltCompiledTransform(string xslt)
    // {
    //     if (Transforms.TryGetValue(xslt, out var transform))
    //         return transform;
    //
    //     var xsltByteArr = Encoding.UTF8.GetBytes(xslt);
    //
    //     using var xsltStream   = new MemoryStream(xsltByteArr);
    //     using var xsltReader   = XmlReader.Create(xsltStream);
    //     var       newTransform = new XslCompiledTransform();
    //     newTransform.Load(xsltReader, XsltSettings, null);
    //
    //     Transforms.TryAdd(xslt, newTransform);
    //
    //     return newTransform;
    // }
}