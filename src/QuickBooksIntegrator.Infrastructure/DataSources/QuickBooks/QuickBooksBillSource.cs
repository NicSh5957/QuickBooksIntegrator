using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Bills;
using QuickBooksIntegrator.Infrastructure.Constants;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels;

namespace QuickBooksIntegrator.Infrastructure.DataSources.QuickBooks;

public class QuickBooksBillSource : IDataSource<BillDto>
{
    private readonly QuickBooksBaseService _baseService;

    public QuickBooksBillSource(QuickBooksBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<List<BillDto>> GetDataListAsync()
    {
        var responseXml = _baseService.SendRequest(QuickBooksXmlCommands.GetBillData);
        var response = _baseService.DeserializeResponse<QuickBooksResponse>(responseXml);
        var bills = response?.MessagesResponse?.BillResponse?.Bills;
        
        return bills.Select(bill => new BillDto
        {
            BillNumber = bill.BillNumber,
            Date = DateTime.Parse(bill.Date),
            AmountDue = bill.AmountDue
        }).ToList();
    }

    public Task AddDataAsync(BillDto newObject)
    {
        throw new NotImplementedException();
    }

    public Task<BillDto> GetDataAsync() => throw new NotImplementedException();
}