using Microsoft.EntityFrameworkCore;

namespace TimeTamer.DataLayer.UnitOfWork;

public class TimeTamerUow(DbContext context) : IUnitOfWork
{
    private bool _disposed = false;
    private readonly Dictionary<string, object> _repositories = [];

    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T).Name;

        if (!_repositories.TryGetValue(type, out object? value))
        {
            var repositoryType = typeof(Repository<>);

            object repositoryInstance = 
                Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context)
                ?? throw new NullReferenceException("Repository instance could not be created.");

            value = repositoryInstance;
            _repositories.Add(type, value);
        }

        return (IRepository<T>)value;
    }

    public async Task<bool> SaveChangesAsync()
    {
        // Save changes with the context and return success status.
        return await context.SaveChangesAsync() > 0;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
