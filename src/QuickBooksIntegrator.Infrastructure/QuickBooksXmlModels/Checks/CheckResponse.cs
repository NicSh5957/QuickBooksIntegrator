using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Checks;

public class CheckResponse
{
    [XmlElement("CheckRet")]
    public List<CheckData> Checks { get; set; }
}