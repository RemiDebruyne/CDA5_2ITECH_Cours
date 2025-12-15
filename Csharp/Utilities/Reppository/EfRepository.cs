using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;
using Utilities.Interfaces;


namespace Utilities.Reppository;

public class EfRepository<T>(ApplicationDbContext context) : IEfRepository<T, int> where T : Entity
{
    protected ApplicationDbContext DbContext => context;

    protected DbSet<T> DbSet => context.Set<T>();

    public T Add(T entity)
    {
        return DbSet.Add(entity).Entity;
    }

    public void Delete(T entity)
    {
        DbContext.Entry(entity).State = EntityState.Deleted;
    }

    public List<T> GetAll()
    {
        return DbSet.ToList();
    }

    public T GetById(int id)
    {
        return DbSet.Find(id);
    }

    public void Update(int id, T entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;

        IEnumerable<ReferenceEntry> ownedProperties = DbContext.Entry(entity).References.Where(reference => reference.TargetEntry?.Metadata.IsOwned() == true);

        foreach(var entityEntriy in ownedProperties
            .Select(ownedProperties => ownedProperties.TargetEntry)
            .Where(entityEntry => entityEntry != null))
        {
            entityEntriy.State = EntityState.Modified;
        }
    }

    public void SaveChanges()
    {
        DbContext.SaveChanges();
    }
}
