using Microsoft.EntityFrameworkCore;

namespace TaskTamer.DataLayer.UnitOfWork;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;
    private DbSet<T> _entities;

    public Repository(DbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        // Entity Framework automatically tracks entity changes,
        // so we just need to mark the entity as modified.
        _entities.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        _entities.Remove(entity);
        return Task.CompletedTask;
    }
}

