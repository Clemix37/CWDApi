using AutoMapper;
using CWDApi.Repositories;

namespace CWDApi.Services
{
    public interface IGenericService<CreateDto, ReadDto, UpdateDto>
        where ReadDto : class
        where CreateDto : class
        where UpdateDto : class
    {
        Task<IEnumerable<ReadDto>> GetAllAsync();
        Task<ReadDto?> GetByIdAsync(int id);
        Task<ReadDto?> CreateAsync(CreateDto dto);
        Task<ReadDto?> UpdateAsync(UpdateDto dto);
        Task<bool> DeleteByIdAsync(int id);
    }

    public class GenericService<TEntity, CreateDto, ReadDto, UpdateDto>(IGenericRepository<TEntity> repo, IMapper mapper)
        : IGenericService<CreateDto, ReadDto, UpdateDto>
        where ReadDto : class
        where CreateDto : class
        where UpdateDto : class
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repo = repo;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ReadDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadDto>>(entities);
        }

        public async Task<ReadDto?> GetByIdAsync(int id)
        {
            TEntity? entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ReadDto>(entity);
        }

        public async Task<ReadDto?> CreateAsync(CreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
            return _mapper.Map<ReadDto>(entity);
        }

        public async Task<ReadDto?> UpdateAsync(UpdateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _repo.Update(entity);
            await _repo.SaveChangesAsync();
            return _mapper.Map<ReadDto>(entity);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            bool deleted = await _repo.DeleteByIdAsync(id);
            if (!deleted) return false;
            await _repo.SaveChangesAsync();
            return true;
        }

    }
}
