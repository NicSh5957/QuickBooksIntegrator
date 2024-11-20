using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Checks;

namespace QuickBooksIntegrator.Infrastructure.DataSources.DataBsae;

public class DatabaseCheckSource : IDataSource<CheckDto>
{
    public async Task<List<CheckDto>> GetDataListAsync()
    {
        return await Task.FromResult(new List<CheckDto>
        {
            new() { CheckNumber = "SomeCheckNumber_1", Date = DateTime.Now, Amount = 500.00M },
            new() { CheckNumber = "SomeCheckNumber_2", Date = DateTime.Now, Amount = 750.25M }
        });
    }

    public Task AddDataAsync(CheckDto newObject)
    {
        throw new NotImplementedException();
    }

    public Task<CheckDto> GetDataAsync() => throw new NotImplementedException();
}