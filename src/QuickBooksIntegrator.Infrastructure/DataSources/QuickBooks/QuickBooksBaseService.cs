using Common.Extensions;
using Microsoft.Extensions.Logging;
using QBXMLRP2Lib;
using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.Infrastructure.Configurations;
using System.Xml.Serialization;

namespace QuickBooksIntegrator.Infrastructure.DataSources.QuickBooks;

public class QuickBooksBaseService : IQuickBooksService
{
    private readonly QuickBooksConfig _config;
    private readonly ILogger _logger;

    public QuickBooksBaseService(QuickBooksConfig config, ILogger logger)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    private RequestProcessor2 InitializeRequestProcessor()
    {
        var requestProcessor = new RequestProcessor2();
        requestProcessor.OpenConnection("", "QuickBooksIntegration");
        return requestProcessor;
    }

    public string SendRequest(string xmlRequest)
    {
        if (string.IsNullOrWhiteSpace(xmlRequest))
            throw new ArgumentException("Request cannot be null or empty.", nameof(xmlRequest));

        var requestProcessor = InitializeRequestProcessor();

        try
        {
            var ticket = requestProcessor.BeginSession(_config.CompanyFilePath, QBFileMode.qbFileOpenDoNotCare);
            var response = requestProcessor.ProcessRequest(ticket, xmlRequest);
            requestProcessor.EndSession(ticket);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "QuickBooks error occurred: {DetailedError}", ex.JoinInnerExceptions());
            throw;
        }
        finally
        {
            requestProcessor.CloseConnection();
        }
    }

    public T DeserializeResponse<T>(string xmlResponse)
    {
        if (string.IsNullOrWhiteSpace(xmlResponse))
            throw new ArgumentException("Response cannot be null or empty.", nameof(xmlResponse));

        var serializer = new XmlSerializer(typeof(T));
        using var stringReader = new StringReader(xmlResponse);
        return (T)serializer.Deserialize(stringReader)!;
    }
}