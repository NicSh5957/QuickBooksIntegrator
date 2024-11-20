using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Invoices;
using QuickBooksIntegrator.Infrastructure.Constants;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels;

namespace QuickBooksIntegrator.Infrastructure.DataSources.QuickBooks;

public class QuickBooksInvoiceSource : IDataSource<InvoiceDto>
{
    private readonly QuickBooksBaseService _baseService;

    public QuickBooksInvoiceSource(QuickBooksBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<List<InvoiceDto>> GetDataListAsync()
    {
        var responseXml = _baseService.SendRequest(QuickBooksXmlCommands.GetInvoiceData);
        var response = _baseService.DeserializeResponse<QuickBooksResponse>(responseXml);
        var invoices = response?.MessagesResponse?.InvoiceResponse?.Invoices;

        return invoices.Select(invoice => new InvoiceDto
        {
            InvoiceNumber = invoice.InvoiceNumber,
            Date = DateTime.Parse(invoice.Date),
            Amount = invoice.Amount
        }).ToList();
    }

    public async Task AddDataAsync(InvoiceDto invoice)
    {
        var xmlRequest = string.Format(QuickBooksXmlCommands.AddInvoiceData, invoice.CustomerName, 
            invoice.Date.ToString("yyyy-MM-dd"), invoice.ItemName, invoice.Amount, invoice.Quantity);
        _baseService.SendRequest(xmlRequest);
    }

    public Task<InvoiceDto> GetDataAsync() => throw new NotImplementedException();
}