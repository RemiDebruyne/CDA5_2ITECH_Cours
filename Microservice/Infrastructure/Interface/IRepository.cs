using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface;

public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T entity);

    Task<T> GetByIdAsync(int id);

    Task<List<T>> GetAllAsync();

    void Update(int id, T entity);

    void Delete(T entity);

    Task SaveChangesAsync();
}
