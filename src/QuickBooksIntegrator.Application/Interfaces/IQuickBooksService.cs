namespace QuickBooksIntegrator.Application.Interfaces;

public interface IQuickBooksService
{
    string SendRequest(string xmlRequest);
}