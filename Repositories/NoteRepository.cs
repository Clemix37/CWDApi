using CWDApi.Data;
using CWDApi.Entities;

namespace CWDApi.Repositories
{
    public interface INoteRepository : IGenericRepository<Note>
    {
    }

    public class NoteRepository(ApiContext context) : GenericRepository<Note>(context), INoteRepository
    {
    }
}
