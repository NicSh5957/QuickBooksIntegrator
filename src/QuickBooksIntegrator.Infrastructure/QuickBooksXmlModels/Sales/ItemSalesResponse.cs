using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Sales;

public class ItemSalesResponse
{
    [XmlElement("ItemSalesTaxRet")]
    public List<ItemSalesData> Items { get; set; }
}