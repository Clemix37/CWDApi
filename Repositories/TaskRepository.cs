using CWDApi.Data;
using CWDApi.Entities;

namespace CWDApi.Repositories
{
    public interface ITaskRepository : IGenericRepository<TaskItem>
    {
    }

    public class TaskRepository(ApiContext context) : GenericRepository<TaskItem>(context), ITaskRepository
    {
    }
}
