using CWDApi.Data;
using Microsoft.EntityFrameworkCore;

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

    public class GenericRepository<T>(ApiContext context) : IGenericRepository<T>
        where T : class
    {
        private readonly ApiContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) =>
            await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity) =>
            await _dbSet.AddAsync(entity);

        public void Update(T entity) =>
            _dbSet.Update(entity);

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (id == 0) return false;
            T? entity = await GetByIdAsync(id);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            return true;
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
