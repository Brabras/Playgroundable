using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using XmlPlayground.Content;

var transform = Assembly.GetExecutingAssembly().GetManifestResourceStream("XmlPlayground.Content.UNTransform.xslt");
var xml = Assembly.GetExecutingAssembly().GetManifestResourceStream("XmlPlayground.Content.UN.xml");

var xsltArgumentList = new XsltArgumentList();
xsltArgumentList.AddExtensionObject(CollectorExtensions.Namespace, new CollectorExtensions());

var myXslTrans = new XslCompiledTransform();
var xsltSettings = new XsltSettings { EnableScript = true };

var sb = new StringBuilder();

var xmlReaderSettings = new XmlReaderSettings
{
    DtdProcessing = DtdProcessing.Parse
};


using (var xmlReader = XmlReader.Create(xml!, xmlReaderSettings))
using (var xmlWriter = XmlWriter.Create(sb))
using (var xsltReader = XmlReader.Create(transform!))
{
    myXslTrans.Load(xsltReader, xsltSettings, null);
    myXslTrans.Transform(xmlReader, xsltArgumentList, xmlWriter);
}

var resultPayload = sb.ToString();

var isResultValid = ValidateResult(resultPayload);

if (!isResultValid)
    Console.WriteLine("Invalid");
else
    Console.WriteLine("Valid");


static bool ValidateResult(string resultPayload)
{
    using (var xsdStream = Assembly.GetExecutingAssembly()
               .GetManifestResourceStream("XmlPlayground.Content.BlackListSchema.xsd"))
    {
        using (var xsdReaderStream = XmlReader.Create(xsdStream!))
        {
            var validationSettings = new XmlReaderSettings();
            validationSettings.Schemas.Add(null, xsdReaderStream);
            validationSettings.ValidationType = ValidationType.Schema;
            validationSettings.ValidationEventHandler += BooksSettingsValidationEventHandler!;

            var xmlByteArr = Encoding.Unicode.GetBytes(resultPayload);
            using (var xmlResultStream = new MemoryStream(xmlByteArr))
            using (var xmlResultReader = XmlReader.Create(xmlResultStream, validationSettings))
            {
                try
                {
                    while (xmlResultReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }

    return true;
}

static void BooksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
{
    throw new Exception(e.Message);
}