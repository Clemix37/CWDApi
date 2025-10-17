using CWDApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWDApi.Data
{
    public class ApiContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Habit> Habits { get; set; }
    }
}
