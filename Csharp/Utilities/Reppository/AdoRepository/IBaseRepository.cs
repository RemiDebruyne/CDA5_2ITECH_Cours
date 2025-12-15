using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Reppository.AdoRepository;

public interface IBaseRepository<T> where T : class, new()
{
    bool Add(T entity);

    bool Update(int id, T entity);

    List<T> GetAll(Dictionary<string, string>? queryParameters = null);

    T? GetById(int id);

    bool Delete(int id, SqlConnection connection, SqlTransaction transaction);
}
