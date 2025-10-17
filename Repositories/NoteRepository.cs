using CWDApi.Data;
using CWDApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWDApi.Repositories
{
    public interface INoteRepository : IGenericRepository<Note>
    {
    }

    public class NoteRepository(ApiContext context) : INoteRepository
    {
        private readonly ApiContext _context = context;

        public async Task<IEnumerable<Note>> GetAllAsync() =>
            await _context.Notes.ToListAsync();

        public async Task<Note?> GetByIdAsync(int id) =>
            await _context.Notes.FindAsync(id);

        public async Task AddAsync(Note note) =>
            await _context.Notes.AddAsync(note);

        public void Update(Note note) =>
            _context.Notes.Update(note);

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (id == 0) return false;
            Note? note = await GetByIdAsync(id);
            if (note == null) return false;
            _context.Notes.Remove(note);
            return true;
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
