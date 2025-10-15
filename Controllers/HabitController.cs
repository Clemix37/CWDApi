using CWDApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CWDApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HabitController : ControllerBase
    {
        private static List<CWDHabit> Habits = [];

        [HttpGet("")]
        public ActionResult<List<CWDHabit>> Get()
        {
            return Habits;
        }

        [HttpGet("{id}")]
        public ActionResult<CWDHabit> GetById(int id)
        {
            CWDHabit? habit = Habits.FirstOrDefault(t => t.Id == id);
            return habit != null ? habit : NotFound($"Habit with id {{{id}}} not existing");
        }

        [HttpPost("")]
        public IActionResult Create(CWDHabit newHabit)
        {
            if (newHabit.Id != 0) return BadRequest("Cannot create with Id different from zero");
            Habits.Add(newHabit);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<CWDHabit> Update(int id, CWDHabit newHabit)
        {
            // Impossible id
            if (id == 0) return BadRequest("Impossible id (0)");
            // Id not existing
            if (!Habits.Select(habit => habit.Id).Contains(id)) return NotFound($"Habit with id {{{id}}} not existing");
            // Update the id of the new habit
            newHabit.Id = id;
            // Save the habits
            Habits = [.. Habits.Select(habit => habit.Id == id ? newHabit : habit)];
            // Return the edited habit
            return newHabit;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest("Id cannot be zero");
            CWDHabit? habit = Habits.FirstOrDefault(habit => habit.Id == id);
            if (habit == null) return NotFound($"Habit with id {{{id}}} not existing");
            Habits.Remove(habit);
            return Ok();
        }
    }
}
