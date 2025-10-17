using AutoMapper;
using CWDApi.DTOs;
using CWDApi.Entities;
using CWDApi.Repositories;

namespace CWDApi.Services
{
    public interface IHabitService : IGenericService<HabitCreateDto, HabitReadDto, HabitUpdateDto>
    {
    }

    public class HabitService(IHabitRepository repo, IMapper mapper)
        : GenericService<Habit, HabitCreateDto, HabitReadDto, HabitUpdateDto>(repo, mapper), IHabitService
    {
    }
}
