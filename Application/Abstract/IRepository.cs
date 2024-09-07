namespace Application.Abstract;

public interface IRepository<T>
    where T : class, IBaseEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
        Expression<Func<T, object>>? orderBy = null,
        params Expression<Func<T, object>>[] includeProperties);

    Task<T?> GetAsync(Expression<Func<T, bool>>? predicate = null,
        params Expression<Func<T, object>>[] includeProperties);

    Task<T?> GetByIdAsync(object id);

    Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    Task<T> CreateAsync(T entity);
    T Update(T entity);
    void Delete(T entity);
}
