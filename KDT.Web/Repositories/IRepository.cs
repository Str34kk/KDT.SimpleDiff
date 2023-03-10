using System.Linq.Expressions;
using KDT.Web.Entities;

namespace KDT.Web.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> Add(T entity);
    
    Task<T?> GetByIdAsync(int id);
    
    Task<IEnumerable<T>> GetListAsync();
    
    Task<T> Update(T entity);

    Task<T> Delete(T entity);
}