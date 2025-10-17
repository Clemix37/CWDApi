using CWDApi.Data;
using CWDApi.Entities;

namespace CWDApi.Repositories
{
    public interface IHabitRepository : IGenericRepository<Habit>
    {
    }

    public class HabitRepository(ApiContext context) : GenericRepository<Habit>(context), IHabitRepository
    {
    }
}
