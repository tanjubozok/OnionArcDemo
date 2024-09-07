namespace Persistence.Repositories;

public class Repository<T> : IRepository<T>
    where T : class, IBaseEntity, new()
{
    private readonly DatabaseContext _context;
    public DbSet<T> _set => _context.Set<T>();

    public Repository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = _set.AsNoTracking();
        query = Repository<T>.ApplyPredicate(query, predicate);
        return await query.AnyAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = _set.AsNoTracking();
        query = Repository<T>.ApplyPredicate(query, predicate);
        return await query.CountAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _set.AddAsync(entity);
        return entity;
    }

    public void Delete(T entity)
        => _set.Remove(entity);

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, object>>? orderBy = null, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _set.AsNoTracking();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        query = Repository<T>.ApplyPredicate(query, predicate);

        if (orderBy != null)
            query = query.OrderBy(orderBy);

        return await query.ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _set.AsNoTracking();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        query = Repository<T>.ApplyPredicate(query, predicate);
        return await query.SingleOrDefaultAsync();
    }

    public async Task<T?> GetByIdAsync(object id)
        => await _set.FindAsync(id);

    public T Update(T entity)
    {
        _set.Update(entity);
        return entity;
    }

    private static IQueryable<T> ApplyPredicate(IQueryable<T> query, Expression<Func<T, bool>> predicate)
        => predicate != null
        ? query.Where(predicate)
        : query;
}
