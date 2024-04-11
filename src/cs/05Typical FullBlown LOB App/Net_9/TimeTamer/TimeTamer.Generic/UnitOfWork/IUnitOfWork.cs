namespace TimeTamer.DataLayer.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<bool> SaveChangesAsync();
    IRepository<T> Repository<T>() where T : class;
}
