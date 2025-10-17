using AutoMapper;
using CWDApi.DTOs;
using CWDApi.Entities;
using CWDApi.Repositories;

namespace CWDApi.Services
{
    public interface INoteService : IGenericService<NoteCreateDto, NoteReadDto, NoteUpdateDto>
    {
    }

    public class NoteService(INoteRepository repo, IMapper mapper)
        : GenericService<Note, NoteCreateDto, NoteReadDto, NoteUpdateDto>(repo, mapper), INoteService
    {
    }
}
