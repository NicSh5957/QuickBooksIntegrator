using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Sales;

public class ItemSalesData
{
    [XmlElement("ListID")]
    public string ListId { get; set; }

    [XmlElement("Name")]
    public string ItemName { get; set; }

    [XmlElement("SalesTaxRate")]
    public decimal SalesTaxRate { get; set; }

    [XmlElement("Description")]
    public string Description { get; set; }

    [XmlElement("Amount")]
    public decimal Amount { get; set; }
}