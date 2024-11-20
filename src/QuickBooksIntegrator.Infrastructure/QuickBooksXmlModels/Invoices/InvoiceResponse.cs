using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Invoices;

public class InvoiceResponse
{
    [XmlElement("InvoiceRet")]
    public List<InvoiceData> Invoices { get; set; }
}