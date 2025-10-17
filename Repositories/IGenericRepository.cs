namespace CWDApi.Repositories
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T task);
        void Update(T task);
        Task<bool> DeleteByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
