using EventMi.Infrastructure.Contracts;

namespace EventMi.Infrastructure.Common;

public interface IRepository
{
    Task AddAsync<T>(T entity) where T : class;

    void Delete<T>(T entity) where T : class, IDeletable;

    IQueryable<T> AllReadonly<T>() where T : class;

    IQueryable<T> AllWithDeletedReadOnly<T>() where T : class, IDeletable;

    IQueryable<T> All<T>() where T : class;

    IQueryable<T> AllWithDeleted<T>() where T : class, IDeletable;

    Task<T?> GetById<T>(int id) where T : class;

    Task<int> SaveChangesAsync();
}