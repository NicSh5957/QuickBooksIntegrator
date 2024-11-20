using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels.Companies;

public class CompanyData
{
    [XmlElement("CompanyName")]
    public string Name { get; set; }

    [XmlElement("Phone")]
    public string Phone { get; set; }

    [XmlElement("Address")]
    public Address Address { get; set; }
}

public class Address
{
    [XmlElement("Addr1")]
    public string Addr1 { get; set; }
}