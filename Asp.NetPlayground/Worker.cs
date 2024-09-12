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
    const string UNTransformPath = "Content/UNTransform.xslt";

    private static readonly Dictionary<string, string> dict = new()
    {
        { EufsPath, EufsTransformPath },
        { OfacPath, OfacTransformPath },
        { UnPath, UNTransformPath }
    };

    private readonly Dictionary<string, string> XsltXmls = new();

    private static readonly XsltArgumentList _xsltArgumentList = new();
    private static readonly XsltSettings _xsltSettings = new() { EnableScript            = true };
    private static readonly XmlReaderSettings _xmlReaderSettings = new() { DtdProcessing = DtdProcessing.Parse };

    private static readonly Dictionary<string, XslCompiledTransform> _transforms = new();

    public Worker()
    {
        _xsltArgumentList.AddExtensionObject(XsltExtensions.Namespace, new XsltExtensions());
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        foreach (var keyValue in dict)
        {
            var xmlString  = File.ReadAllText(Path.Combine(".", keyValue.Key));
            var xsltString = File.ReadAllText(Path.Combine(".", keyValue.Value));

            XsltXmls.Add(xsltString, xmlString);
        }

        Console.WriteLine("Make first snapshot: files read");
        Console.ReadLine();
        var cycleIncrement = 1;

        while (true)
        {
            foreach (var keyValue in XsltXmls)
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
        }
    }

    private static string TransformPayload(string xslt, string xml)
    {
        var getTransformResult = GetXsltCompiledTransform(xslt);
        // var getTransformResult = GetCachedXsltCompiledTransform(xslt);


        using var xmlReader = XmlReader.Create(new StringReader(xml), _xmlReaderSettings);
        using var xmlWriter = new StringWriter();
        getTransformResult.Transform(xmlReader, _xsltArgumentList, xmlWriter);

        return xmlWriter.ToString();
    }

    private static XslCompiledTransform GetXsltCompiledTransform(string xslt)
    {
        var xsltByteArr = Encoding.UTF8.GetBytes(xslt);

        using var xsltStream   = new MemoryStream(xsltByteArr);
        using var xsltReader   = XmlReader.Create(xsltStream);
        var       newTransform = new XslCompiledTransform();
        newTransform.Load(xsltReader, _xsltSettings, null);

        return newTransform;
    }

    private static XslCompiledTransform GetCachedXsltCompiledTransform(string xslt)
    {
        if (_transforms.TryGetValue(xslt, out var transform))
            return transform;

        var xsltByteArr = Encoding.UTF8.GetBytes(xslt);

        using var xsltStream   = new MemoryStream(xsltByteArr);
        using var xsltReader   = XmlReader.Create(xsltStream);
        var       newTransform = new XslCompiledTransform();
        newTransform.Load(xsltReader, _xsltSettings, null);

        _transforms.TryAdd(xslt, newTransform);

        return newTransform;
    }
}