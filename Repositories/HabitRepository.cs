using CWDApi.Data;
using CWDApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWDApi.Repositories
{
    public interface IHabitRepository : IGenericRepository<Habit>
    {
    }

    public class HabitRepository(ApiContext context) : IHabitRepository
    {
        private readonly ApiContext _context = context;

        public async Task<IEnumerable<Habit>> GetAllAsync() =>
            await _context.Habits.ToListAsync();

        public async Task<Habit?> GetByIdAsync(int id) =>
            await _context.Habits.FindAsync(id);

        public async Task AddAsync(Habit note) =>
            await _context.Habits.AddAsync(note);

        public void Update(Habit habit) =>
            _context.Habits.Update(habit);

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (id == 0) return false;
            Habit? habit = await GetByIdAsync(id);
            if (habit == null) return false;
            _context.Habits.Remove(habit);
            return true;
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
