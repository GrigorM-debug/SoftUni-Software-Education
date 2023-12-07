using EventMI.Infrastructure.Contracts;
using EventMI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventMI.Infrastructure.Common;

public class Repository : IRepository
{
    private readonly EventMIDbContext _context;

    public Repository(EventMIDbContext context)
    {
        context = _context;
    }

    public async Task<T?> GetById<T>(int id) where T : class
    {
        return await DbSet<T>()
            .FindAsync(id);
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await DbSet<T>().AddAsync(entity);
    }

    public void Delete<T>(T entity) where T : class, IDeletable
    {
        entity.IsActive = false;

        entity.DeletedOn = DateTime.Now;
    }

    public IQueryable<T> AllReadonly<T>() where T : class
    {
        return DbSet<T>().AsNoTracking();
    }

    public IQueryable<T> AllWithDeletedReadOnly<T>() where T : class, IDeletable
    {
        return DbSet<T>().AsNoTracking().IgnoreQueryFilters();
    }

    public IQueryable<T> All<T>() where T : class
    {
        return DbSet<T>();
    }

    public IQueryable<T> AllWithDeleted<T>() where T : class, IDeletable
    {
        return DbSet<T>().IgnoreQueryFilters();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private DbSet<T> DbSet<T>() where T : class
    {
        return _context.Set<T>();
    }
}