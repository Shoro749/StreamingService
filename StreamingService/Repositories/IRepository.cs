namespace StreamingService.Repositories;
public interface IRepository<T>
{
    Task<IEnumerable<T>> GetListDataAsync();

    Task<T?> GetDataAsync(int id);

    Task<bool> DeleteDataAsync(int id);

    Task<bool> AddDataAsync(T data);

    Task<bool> UpdateDataAsync(T data);

}