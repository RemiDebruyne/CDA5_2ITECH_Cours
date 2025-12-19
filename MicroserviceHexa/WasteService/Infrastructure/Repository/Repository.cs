using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WasteApi.Domain.Ports;

namespace WasteApi.Infrastructure.Repository;

public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
{
    protected ApplicationDbContext DbContext => context;

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

    public async Task Update(int id, T entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;

        IEnumerable<ReferenceEntry> ownedProperties = DbContext.Entry(entity).References.Where(reference => reference.TargetEntry?.Metadata.IsOwned() == true);

        foreach (var entityEntriy in ownedProperties
            .Select(ownedProperties => ownedProperties.TargetEntry)
            .Where(entityEntry => entityEntry != null))
        {
            entityEntriy.State = EntityState.Modified;
        }

        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await DbContext.SaveChangesAsync();
    }