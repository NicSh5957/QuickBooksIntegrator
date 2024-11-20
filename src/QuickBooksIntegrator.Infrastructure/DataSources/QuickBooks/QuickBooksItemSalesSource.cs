using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.ItemSales;
using QuickBooksIntegrator.Infrastructure.Constants;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels;

namespace QuickBooksIntegrator.Infrastructure.DataSources.QuickBooks;

public class QuickBooksItemSalesSource : IDataSource<ItemSalesDto>
{
    private readonly QuickBooksBaseService _baseService;

    public QuickBooksItemSalesSource(QuickBooksBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<List<ItemSalesDto>> GetDataListAsync()
    {
        var responseXml = _baseService.SendRequest(QuickBooksXmlCommands.GetItemSalesData);
        var response = _baseService.DeserializeResponse<QuickBooksResponse>(responseXml);
        var items = response?.MessagesResponse?.ItemSalesResponse?.Items;

        return items.Select(item => new ItemSalesDto
        {
            ItemName = item.ItemName,
            Price = item.Amount
        }).ToList();
    }

    public Task AddDataAsync(ItemSalesDto newObject)
    {
        throw new NotImplementedException();
    }

    public Task<ItemSalesDto> GetDataAsync() => throw new NotImplementedException();
}