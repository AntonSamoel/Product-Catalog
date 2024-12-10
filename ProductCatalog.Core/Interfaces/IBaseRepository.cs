

namespace ProductCatalog.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        // NOT Async
        T Update(T entity);
        void Remove(T entity);

        // Async
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> critera, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> critera, string[] includes = null);
        Task<bool> ExistAsync(int id);
    }
}
