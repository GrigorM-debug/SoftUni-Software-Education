using EventMi.Infrastructure.Contracts;
using EventMi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventMi.Infrastructure.Common;

public class Repository : IRepository
{
    private readonly EventMiDbContext _context;

    public Repository(EventMiDbContext context)
    {
        _context = context;
    }

    private DbSet<T> DbSet<T>() where T : class => _context.Set<T>();

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
}