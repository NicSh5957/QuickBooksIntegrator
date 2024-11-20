//using System.Threading.Tasks;
//using Xunit;
//using Moq;
//using QuickBooksIntegrator.Infrastructure.Configurations;
//using QuickBooksIntegrator.Infrastructure.Services;
//using Microsoft.Extensions.Logging;
//using QBXMLRP2Lib;

//namespace QuickBooksIntegrator.Tests.Services;

//public class QuickBooksXmlServiceTests
//{
//    private readonly Mock<ILogger<QuickBooksXmlService>> _loggerMock;
//    private readonly Mock<RequestProcessor2> _requestProcessorMock;
//    private readonly QuickBooksConfig _config;

//    public QuickBooksXmlServiceTests()
//    {
//        _loggerMock = new Mock<ILogger<QuickBooksXmlService>>();
//        _requestProcessorMock = new Mock<RequestProcessor2>();
//        _config = new QuickBooksConfig
//        {
//            CompanyFilePath = "TestCompanyFile.qbw"
//        };
//    }

//    [Fact]
//    public async Task SendRequestAsync_ReturnsXmlResponse()
//    {
//        // Arrange: Пример XML-запроса и ожидаемого ответа
//        var xmlRequest = "<QBXML><CompanyQueryRq /></QBXML>";
//        var expectedResponse = "<QBXML><QBXMLMsgsRs><CompanyQueryRs><CompanyRet><CompanyName>Test Company</CompanyName></CompanyRet></CompanyQueryRs></QBXMLMsgsRs></QBXML>";

//        // Настраиваем мок для RequestProcessor2
//        _requestProcessorMock
//            .Setup(rp => rp.BeginSession(It.IsAny<string>(), It.IsAny<QBFileMode>()))
//            .Returns("TestSession");

//        _requestProcessorMock
//            .Setup(rp => rp.ProcessRequest(It.IsAny<string>(), xmlRequest))
//            .Returns(expectedResponse);

//        _requestProcessorMock
//            .Setup(rp => rp.EndSession(It.IsAny<string>()));

//        _requestProcessorMock
//            .Setup(rp => rp.CloseConnection());

//        var service = new QuickBooksXmlService(_config, _loggerMock.Object);

//        // Act: Вызываем тестируемый метод
//        var result = await service.SendRequestAsync(xmlRequest);

//        // Assert: Проверяем результат
//        Assert.NotNull(result);
//        Assert.Equal(expectedResponse, result);

//        // Проверяем вызовы методов RequestProcessor2
//        _requestProcessorMock.Verify(rp => rp.BeginSession(_config.CompanyFilePath, QBFileMode.qbFileOpenDoNotCare), Times.Once);
//        _requestProcessorMock.Verify(rp => rp.ProcessRequest(It.IsAny<string>(), xmlRequest), Times.Once);
//        _requestProcessorMock.Verify(rp => rp.EndSession(It.IsAny<string>()), Times.Once);
//        _requestProcessorMock.Verify(rp => rp.CloseConnection(), Times.Once);
//    }
//}
