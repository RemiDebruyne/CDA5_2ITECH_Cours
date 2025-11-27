using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_ado_2.Reppository;

public interface IBaseRepository<T> where T : class, new()
{
    bool Add(T entity);

    bool Update(int id, T entity);

    List<T> GetAll();

    T? GetById(int id);

    bool Delete(int id, SqlConnection connection, SqlTransaction transaction);
}
