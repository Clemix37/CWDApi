using CWDApi.Data;
using CWDApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWDApi.Repositories
{
    public interface ITaskRepository : IGenericRepository<TaskItem>
    {
    }

    public class TaskRepository(ApiContext context) : ITaskRepository
    {
        private readonly ApiContext _context = context;

        public async Task<IEnumerable<TaskItem>> GetAllAsync() =>
            await _context.Tasks.ToListAsync();

        public async Task<TaskItem?> GetByIdAsync(int id) =>
            await _context.Tasks.FindAsync(id);

        public async Task AddAsync(TaskItem task) =>
            await _context.Tasks.AddAsync(task);

        public void Update(TaskItem task) =>
            _context.Tasks.Update(task);

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (id == 0) return false;
            TaskItem? task = await GetByIdAsync(id);
            if (task == null) return false;
            _context.Tasks.Remove(task);
            return true;
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
