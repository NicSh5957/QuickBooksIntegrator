using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Companies;
using QuickBooksIntegrator.Infrastructure.Constants;
using QuickBooksIntegrator.Infrastructure.QuickBooksXmlModels;

namespace QuickBooksIntegrator.Infrastructure.DataSources.QuickBooks
{
    public class QuickBooksCompanySource : IDataSource<CompanyDto>
    {
        private readonly QuickBooksBaseService _baseService;

        public QuickBooksCompanySource(QuickBooksBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<CompanyDto> GetDataAsync()
        {
            var responseXml = _baseService.SendRequest(QuickBooksXmlCommands.GetCompanyData);
            var response = _baseService.DeserializeResponse<QuickBooksResponse>(responseXml);
            var companyData = response?.MessagesResponse?.CompanyResponse?.Company;

            return new CompanyDto
            {
                Name = companyData.Name,
                Address = companyData.Address.Addr1,
                Phone = companyData.Phone
            };
        }

        public Task<List<CompanyDto>> GetDataListAsync() => throw new NotImplementedException();
        public Task AddDataAsync(CompanyDto newObject)
        {
            throw new NotImplementedException();
        }
    }
}
