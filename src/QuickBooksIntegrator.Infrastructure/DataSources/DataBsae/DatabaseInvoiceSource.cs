using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Invoices;

namespace QuickBooksIntegrator.Infrastructure.DataSources.DataBsae;

public class DatabaseInvoiceSource : IDataSource<InvoiceDto>
{
    public async Task<List<InvoiceDto>> GetDataListAsync()
    {
        return await Task.FromResult(new List<InvoiceDto>
        {
            new() { InvoiceNumber = "SomeNumber123", Date = DateTime.Now, Amount = 150.0M },
            new() { InvoiceNumber = "SomeNumber1234", Date = DateTime.Now, Amount = 250.0M }
        });
    }

    public Task AddDataAsync(InvoiceDto newObject)
    {
        throw new NotImplementedException();
    }

    public Task<InvoiceDto> GetDataAsync() => throw new NotImplementedException();
}