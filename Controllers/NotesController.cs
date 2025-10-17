using CWDApi.DTOs;
using CWDApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CWDApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController(INoteService service) : Controller
    {
        private readonly INoteService _service = service;

        [HttpGet("")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                var notes = await _service.GetAllAsync();
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id)
        {
            try
            {
                NoteReadDto? note = await _service.GetByIdAsync(id);
                if (note == null) return NotFound(new { message = $"Note with id {id} not found" });
                return Ok(note);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateNote(NoteCreateDto dto)
        {
            try
            {
                NoteReadDto? created = await _service.CreateAsync(dto);
                if (created == null) return StatusCode(500);
                return CreatedAtAction(nameof(GetAllNotes), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateNote(NoteUpdateDto dto)
        {
            try
            {
                NoteReadDto? updated = await _service.UpdateAsync(dto);
                if (updated == null) return BadRequest(new { message = $"Error updating the note with id {dto.Id}" });
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteById(int id)
        {
            try
            {
                bool deleted = await _service.DeleteByIdAsync(id);
                if (!deleted) return NotFound(new { message = $"Note with id {id} not found" });
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
