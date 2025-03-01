using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression);

    Task<TEntity?> CreateAsync(TEntity entity);
    
    Task<IEnumerable<TEntity>> GetAllAsync();
    
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<bool> UpdateAsync(TEntity entity);

    Task<bool> RemoveAsync(TEntity entity);
}