using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels;

[XmlRoot("QBXML")]
public class QuickBooksResponse
{
    [XmlElement("QBXMLMsgsRs")]
    public QuickBooksMessagesResponse MessagesResponse { get; set; }
}