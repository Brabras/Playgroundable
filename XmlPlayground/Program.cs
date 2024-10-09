using System.Text;
using System.Xml;
using System.Xml.Xsl;
using XmlPlayground;

const string eufsPath = "Content/31.07.24_EUFS.xml";
const string ofacPath = "Content/31.07.24_OFAC.xml";
const string unPath   = "Content/31.07.24_UN.xml";

const string eufsTransformPath = "Content/EUFSTransform.xslt";
const string ofacTransformPath = "Content/OFACTransform.xslt";
const string unTransformPath   = "Content/UNTransform.xslt";

var dict = new Dictionary<string, string>
{
    { eufsPath, eufsTransformPath },
    { ofacPath, ofacTransformPath },
    { unPath, unTransformPath }
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

static void TransformPayload(string xslt, string xml)
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