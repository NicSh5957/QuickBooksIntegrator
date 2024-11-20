namespace QuickBooksIntegrator.Application.Interfaces;

public interface IDataSource<T>
{
    Task<T> GetDataAsync();

    Task<List<T>> GetDataListAsync();

    Task AddDataAsync(T newObject);
}
