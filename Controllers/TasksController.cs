using CWDApi.DTOs;
using CWDApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CWDApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController(ITaskService service) : Controller
    {
        private readonly ITaskService _service = service;

        [HttpGet("")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _service.GetAllAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                TaskReadDto? task = await _service.GetByIdAsync(id);
                return task != null ? Ok(task) : NotFound(new { message = $"Task with id {{{id}}} not existing" });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDto dto)
        {
            try
            {
                TaskReadDto? created = await _service.CreateAsync(dto);
                if (created == null) return BadRequest(new { message = "Cannot create with Id different from zero" });
                return CreatedAtAction(nameof(GetAllTasks), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateTask(TaskUpdateDto dto)
        {
            try
            {
                TaskReadDto? updated = await _service.UpdateAsync(dto);
                if (updated == null) return BadRequest(new { message = $"Task with id {dto.Id} not found" });
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskById(int id)
        {
            try
            {
                bool deleted = await _service.DeleteByIdAsync(id);
                if (!deleted) return NotFound(new { message = $"Task with id {id} not found" });
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
