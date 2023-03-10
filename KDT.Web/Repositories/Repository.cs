using KDT.Web.Database;
using KDT.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace KDT.Web.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    #region Constructor

    private readonly KdtDbContext _dbDbContext;

    public Repository(KdtDbContext dbDbContext)
    {
        _dbDbContext = dbDbContext;
    }

    #endregion

    public async Task<T> Add(T entity)
    {
        var entityEntry = _dbDbContext.Set<T>().Add(entity);
        await _dbDbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbDbContext.Set<T>().FindAsync(id);
    }
    
    public async Task<IEnumerable<T>> GetListAsync()
    {
        return await _dbDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> Update(T entity)
    {
        _dbDbContext.Entry(entity).State = EntityState.Modified;
        await _dbDbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> Delete(T entity)
    {
        _dbDbContext.Set<T>().Remove(entity);
        await _dbDbContext.SaveChangesAsync();
        
        return entity;
    }
}