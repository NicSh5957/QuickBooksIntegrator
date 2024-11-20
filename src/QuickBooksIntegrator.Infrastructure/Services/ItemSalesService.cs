using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.ItemSales;

namespace QuickBooksIntegrator.Infrastructure.Services;

public class ItemSalesService
{
    private readonly IDataSource<ItemSalesDto> _dataSource;

    public ItemSalesService(IDataSource<ItemSalesDto> dataSource) => _dataSource = dataSource;

    public async Task<List<ItemSalesDto>> GetItemSalesDataAsync() => await _dataSource.GetDataListAsync();
}