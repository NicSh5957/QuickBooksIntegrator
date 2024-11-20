using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Checks;
using QuickBooksIntegrator.Infrastructure.Constants;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels;

namespace QuickBooksIntegrator.Infrastructure.DataSources.QuickBooks;

public class QuickBooksCheckSource : IDataSource<CheckDto>
{
    private readonly QuickBooksBaseService _baseService;

    public QuickBooksCheckSource(QuickBooksBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<List<CheckDto>> GetDataListAsync()
    {
        var responseXml = _baseService.SendRequest(QuickBooksXmlCommands.GetCheckData);
        var response = _baseService.DeserializeResponse<QuickBooksResponse>(responseXml);
        var checks = response?.MessagesResponse?.CheckResponse?.Checks;

        return checks.Select(check => new CheckDto
        {
            CheckNumber = check.CheckNumber,
            Date = DateTime.Parse(check.Date),
            Amount = check.Amount
        }).ToList();
    }

    public Task AddDataAsync(CheckDto newObject)
    {
        throw new NotImplementedException();
    }

    public Task<CheckDto> GetDataAsync() => throw new NotImplementedException();
}