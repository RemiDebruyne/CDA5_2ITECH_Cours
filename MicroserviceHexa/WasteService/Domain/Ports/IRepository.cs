namespace WasteApi.Domain.Ports;

public interface IRepository<T>
{
    Task<T> AddAsync(T entity);

    Task<T> GetByIdAsync(int id);

    Task<List<T>> GetAllAsync();

    Task Update(int id, T entity);

    void Delete(T entity);

    Task SaveChangesAsync();
}
