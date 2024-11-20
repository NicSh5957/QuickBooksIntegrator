using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Checks;

namespace QuickBooksIntegrator.Infrastructure.Services;

public class CheckService
{
    private readonly IDataSource<CheckDto> _dataSource;

    public CheckService(IDataSource<CheckDto> dataSource) => _dataSource = dataSource;

    public async Task<List<CheckDto>> GetCheckDataAsync() => await _dataSource.GetDataListAsync();
}