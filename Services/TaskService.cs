using AutoMapper;
using CWDApi.DTOs;
using CWDApi.Entities;
using CWDApi.Repositories;

namespace CWDApi.Services
{
    public interface ITaskService : IGenericService<TaskCreateDto, TaskReadDto, TaskUpdateDto>
    {
    }
    public class TaskService(ITaskRepository repo, IMapper mapper)
        : GenericService<TaskItem, TaskCreateDto, TaskReadDto, TaskUpdateDto>(repo, mapper), ITaskService
    {
    }
}
