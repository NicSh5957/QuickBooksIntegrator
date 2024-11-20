using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Bills;

namespace QuickBooksIntegrator.Infrastructure.Services;

public class BillService
{
    private readonly IDataSource<BillDto> _dataSource;

    public BillService(IDataSource<BillDto> dataSource) => _dataSource = dataSource;

    public async Task<List<BillDto>> GetBillDataAsync() => await _dataSource.GetDataListAsync();
}