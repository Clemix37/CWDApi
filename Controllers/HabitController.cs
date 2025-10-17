using CWDApi.DTOs;
using CWDApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CWDApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HabitController(IHabitService service) : Controller
    {
        private readonly IHabitService _service = service;

        [HttpGet("")]
        public async Task<IActionResult> GetAllHabits()
        {
            try
            {
                var habits = await _service.GetAllAsync();
                return Ok(habits);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHabitById(int id)
        {
            try
            {
                HabitReadDto? habit = await _service.GetByIdAsync(id);
                return habit != null ? Ok(habit) : NotFound($"Habit with id {{{id}}} not existing");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateHabit(HabitCreateDto newHabit)
        {
            try
            {
                HabitReadDto? created = await _service.CreateAsync(newHabit);
                if (created == null) return StatusCode(500);
                return CreatedAtAction(nameof(GetAllHabits), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateHabit(HabitUpdateDto dto)
        {
            try
            {
                HabitReadDto? updated = await _service.UpdateAsync(dto);
                if (updated == null) return NotFound(new { message = $"Habit with id {dto.Id} not found" });
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitById(int id)
        {
            try
            {
                bool deleted = await _service.DeleteByIdAsync(id);
                if (!deleted) return NotFound(new { message = $"Habit with id {id} not found" });
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
