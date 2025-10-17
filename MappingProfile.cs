using AutoMapper;
using CWDApi.DTOs;
using CWDApi.Entities;

namespace CWDApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // TaskItem
            CreateMap<TaskItem, TaskReadDto>();
            CreateMap<TaskCreateDto, TaskItem>();
            CreateMap<TaskUpdateDto, TaskItem>();

            // Note
            CreateMap<Note, NoteReadDto>();
            CreateMap<NoteCreateDto, Note>();
            CreateMap<NoteUpdateDto, Note>();

            // Habit
            CreateMap<Habit, HabitReadDto>();
            CreateMap<HabitCreateDto, Habit>();
            CreateMap<HabitUpdateDto, Habit>();
        }
    }
}
