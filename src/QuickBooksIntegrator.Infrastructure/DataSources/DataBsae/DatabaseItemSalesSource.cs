using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.ItemSales;

namespace QuickBooksIntegrator.Infrastructure.DataSources.DataBsae;

public class DatabaseItemSalesSource : IDataSource<ItemSalesDto>
{
    public async Task<List<ItemSalesDto>> GetDataListAsync()
    {
        return await Task.FromResult(new List<ItemSalesDto>
        {
            new() { ItemName = "Какой-то продукт_1", Price = 50.0M },
            new() { ItemName = "Какой-то продукт_2", Price = 75.0M }
        });
    }

    public Task AddDataAsync(ItemSalesDto newObject)
    {
        throw new NotImplementedException();
    }

    public Task<ItemSalesDto> GetDataAsync() => throw new NotImplementedException();
}