using Infrastructure.Interface;
using Infrastructure.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repository;

public class BaseRepository<T>(IApplicationDbContext context) : IRepository<T> where T : BaseEntity
{
    protected IApplicationDbContext DbContext => context;

    protected DbSet<T> DbSet => context.Set<T>();

    public async Task<T> AddAsync(T entity)
    {
        T addedEntity = (await DbSet.AddAsync(entity)).Entity;
        await SaveChangesAsync();
        return addedEntity;
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
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

    public async Task SaveChangesAsync()
    {
        await DbContext.SaveChangesAsync();
    }
}
