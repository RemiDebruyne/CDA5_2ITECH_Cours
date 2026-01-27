using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Interfaces;

public interface IEfRepository<T, Tid> where T : class
{
    T Add(T entity);
    T GetById(Tid id);
    List<T> GetAll();
    void Update(Tid id, T entity);
    void Delete(T entity);

    void SaveChanges();
}
