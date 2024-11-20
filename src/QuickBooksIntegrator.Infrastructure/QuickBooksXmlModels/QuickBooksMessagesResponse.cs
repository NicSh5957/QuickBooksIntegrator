using System.Xml.Serialization;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Bills;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Checks;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Companies;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Invoices;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Sales;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels;

public class QuickBooksMessagesResponse
{
    [XmlElement("CompanyQueryRs")]
    public CompanyResponse CompanyResponse { get; set; }

    [XmlElement("InvoiceQueryRs")]
    public InvoiceResponse InvoiceResponse { get; set; }

    [XmlElement("ItemSalesTaxQueryRs")]
    public ItemSalesResponse ItemSalesResponse { get; set; }

    [XmlElement("BillQueryRs")]
    public BillResponse BillResponse { get; set; }

    [XmlElement("CheckQueryRs")]
    public CheckResponse CheckResponse { get; set; }
}