using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Bills;

namespace QuickBooksIntegrator.Infrastructure.DataSources.DataBsae;

public class DatabaseBillSource : IDataSource<BillDto>
{
    public async Task<List<BillDto>> GetDataListAsync()
    {
        return await Task.FromResult(new List<BillDto>
        {
            new() { BillNumber = "SomeNumber", Date = DateTime.Now, AmountDue = 100.50M },
            new() { BillNumber = "SomeNumber", Date = DateTime.Now, AmountDue = 200.75M }
        });
    }

    public Task AddDataAsync(BillDto newObject)
    {
        throw new NotImplementedException();
    }

    public Task<BillDto> GetDataAsync() => throw new NotImplementedException();
}