using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Companies;

public class CompanyResponse
{
    [XmlElement("CompanyRet")]
    public CompanyData Company { get; set; }
}