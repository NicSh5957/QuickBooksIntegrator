using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Bills;

public class BillResponse
{
    [XmlElement("BillRet")]
    public List<BillData> Bills { get; set; }
}