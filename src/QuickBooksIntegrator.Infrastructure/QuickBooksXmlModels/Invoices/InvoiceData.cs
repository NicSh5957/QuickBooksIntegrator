using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Invoices;

public class InvoiceData
{
    [XmlElement("TxnID")]
    public string TransactionId { get; set; }

    [XmlElement("RefNumber")]
    public string InvoiceNumber { get; set; }

    [XmlElement("TxnDate")]
    public string Date { get; set; }

    [XmlElement("TotalAmount")]
    public decimal Amount { get; set; }
}