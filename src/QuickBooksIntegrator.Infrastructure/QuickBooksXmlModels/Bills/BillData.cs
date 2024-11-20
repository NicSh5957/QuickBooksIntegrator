using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Bills;

public class BillData
{
    [XmlElement("TxnID")]
    public string TransactionId { get; set; }

    [XmlElement("RefNumber")]
    public string BillNumber { get; set; }

    [XmlElement("TxnDate")]
    public string Date { get; set; }

    [XmlElement("AmountDue")]
    public decimal AmountDue { get; set; }
}