using CWDApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace CWDApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private static List<CWDNote> Notes = [];


        [HttpGet("")]
        public ActionResult<List<CWDNote>> Get()
        {
            return Notes;
        }

        [HttpGet("{id}")]
        public ActionResult<CWDNote> GetById(int id)
        {
            CWDNote? note = Notes.FirstOrDefault(n => n.Id == id);
            if (note == null) return NotFound($"Note with id {{{id}}} not existing");
            return note;
        }

        [HttpPost("")]
        public IActionResult Create(CWDNote newNote)
        {
            if (newNote.Id != 0) return BadRequest("Cannot create with Id different from zero");
            Notes.Add(newNote);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<CWDNote> Update(int id, CWDNote newNote)
        {
            // Impossible id
            if (id == 0) return BadRequest("Impossible id (0)");
            // Id not existing
            if (!Notes.Select(note => note.Id).Contains(id)) return NotFound($"Note with id {{{id}}} not existing");
            // Update the id of the new note
            newNote.Id = id;
            // Save the notes
            Notes = [.. Notes.Select(note => note.Id == id ? newNote : note)];
            // Return the edited note
            return newNote;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            CWDNote? note = Notes.FirstOrDefault(n => n.Id == id);
            if (note == null) return NotFound($"Note with id {{{id}}} not existing");
            Notes.Remove(note);
            return Ok();
        }
    }
}
