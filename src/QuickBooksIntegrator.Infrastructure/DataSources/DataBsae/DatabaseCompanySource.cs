using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Companies;

namespace QuickBooksIntegrator.Infrastructure.DataSources.DataBsae;

public class DatabaseCompanySource : IDataSource<CompanyDto>
{
    public async Task<CompanyDto> GetDataAsync()
    {
        return await Task.FromResult(new CompanyDto
        {
            Name = "My Company",
            Address = "My Company Address",
            Phone = "(123) 456-7890"
        });
    }

    public Task<List<CompanyDto>> GetDataListAsync() => throw new NotImplementedException();
    public Task AddDataAsync(CompanyDto newObject)
    {
        throw new NotImplementedException();
    }
}