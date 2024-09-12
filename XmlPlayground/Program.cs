using System.Text;
using System.Xml;
using System.Xml.Xsl;
using XmlPlayground;

const string EufsPath = "Content/31.07.24_EUFS.xml";
const string OfacPath = "Content/31.07.24_OFAC.xml";
const string UnPath   = "Content/31.07.24_UN.xml";

const string EufsTransformPath = "Content/EUFSTransform.xslt";
const string OfacTransformPath = "Content/OFACTransform.xslt";
const string UNTransformPath   = "Content/UNTransform.xslt";

var dict = new Dictionary<string, string>
{
    { EufsPath, EufsTransformPath },
    { OfacPath, OfacTransformPath },
    { UnPath, UNTransformPath }
};

var iterationCount = 0;

while (true)
{
    foreach (var list in dict)
    {
        var xml  = await File.ReadAllTextAsync(Path.Combine(".", list.Key));
        var xslt = await File.ReadAllTextAsync(Path.Combine(".", list.Value));

        TransformPayload(xslt, xml);
    }

    await Task.Delay(TimeSpan.FromSeconds(1));
    GC.Collect();
    Console.WriteLine($"{++iterationCount} Iteration complete");
}

Console.WriteLine("Enter to GC collect");
Console.ReadLine();


Console.WriteLine("Enter to exit");
Console.ReadLine();


static string TransformPayload(string xslt, string xml)
{
    var xsltArgumentList = new XsltArgumentList();
    xsltArgumentList.AddExtensionObject(XsltExtensions.Namespace, new XsltExtensions());

    var myXslTrans   = new XslCompiledTransform(false);
    var xsltSettings = new XsltSettings { EnableScript = true };

    var sb = new StringBuilder();

    var xmlReaderSettings = new XmlReaderSettings
    {
        DtdProcessing = DtdProcessing.Parse
    };

    var xsltByteArr = Encoding.UTF8.GetBytes(xslt);
    using (var xsltStream = new MemoryStream(xsltByteArr))
    using (var xmlReader = XmlReader.Create(new StringReader(xml), xmlReaderSettings))
    using (var xmlWriter = XmlWriter.Create(sb))
    using (var xsltReader = XmlReader.Create(xsltStream))
    {
        myXslTrans.Load(xsltReader, xsltSettings, null);
        myXslTrans.Transform(xmlReader, xsltArgumentList, xmlWriter);
    }

    return sb.ToString();
}

// static string TransformPayloadSax(string xslt, string xml)
// {
//     var processor = new Processor();
//
//     processor.RegisterExtensionFunction(new TrimFunction());
//     processor.RegisterExtensionFunction(new FullNameFunction());
//     processor.RegisterExtensionFunction(new ConcatFunction());
//
//
//     var xsltByteArr = Encoding.UTF8.GetBytes(xslt);
//     var xmlByteArr  = Encoding.UTF8.GetBytes(xml);
//
//     using var xsltStream = new MemoryStream(xsltByteArr);
//     using var xmlStream  = new MemoryStream(xmlByteArr);
//     using var writer     = new StringWriter();
//
//     var compiler   = processor.NewXsltCompiler();
//     var executable = compiler.Compile(xsltStream);
//
//     var transformer = executable.Load();
//     transformer.SetInputStream(xmlStream, new Uri("https://brabras.site"));
//     var serializer = processor.NewSerializer(writer);
//     transformer.Run(serializer);
//     return writer.ToString();
// }