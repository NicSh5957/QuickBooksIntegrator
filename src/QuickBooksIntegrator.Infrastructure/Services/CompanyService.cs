using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Companies;

namespace QuickBooksIntegrator.Infrastructure.Services;

public class CompanyService
{
    private readonly IDataSource<CompanyDto> _dataSource;

    public CompanyService(IDataSource<CompanyDto> dataSource) => _dataSource = dataSource;

    public async Task<CompanyDto> GetCompanyDataAsync() => await _dataSource.GetDataAsync();
}