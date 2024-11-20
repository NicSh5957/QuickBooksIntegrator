using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Invoices;

namespace QuickBooksIntegrator.Infrastructure.Services;

public class InvoiceService
{
    private readonly IDataSource<InvoiceDto> _dataSource;

    public InvoiceService(IDataSource<InvoiceDto> dataSource) => _dataSource = dataSource;

    public async Task<List<InvoiceDto>> GetInvoiceDataAsync() => await _dataSource.GetDataListAsync();

    public async Task AddInvoiceAsync(InvoiceDto invoice) => await _dataSource.AddDataAsync(invoice);
}