using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Checks;

public class CheckData
{
    [XmlElement("TxnID")]
    public string TransactionId { get; set; }

    [XmlElement("RefNumber")]
    public string CheckNumber { get; set; }

    [XmlElement("TxnDate")]
    public string Date { get; set; }

    [XmlElement("Amount")]
    public decimal Amount { get; set; }
}