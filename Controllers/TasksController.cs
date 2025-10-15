using CWDApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace CWDApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : Controller
    {
        private static List<CWDTask> Tasks =
        [
            new CWDTask()
            {
                Id = 1,
                Name = "Un",
            },
            new CWDTask()
            {
                Id = 2,
                Name = "Deux",
            },
        ];


        [HttpGet("")]
        public ActionResult<List<CWDTask>> Get()
        {
            return Tasks;
        }

        [HttpGet("{id}")]
        public ActionResult<CWDTask> GetById(int id)
        {
            CWDTask? task = Tasks.FirstOrDefault(t => t.Id == id);
            return task != null ? task : NotFound($"Task with id {{{id}}} not existing");
        }

        [HttpPost("")]
        public IActionResult Create(CWDTask newTask)
        {
            if (newTask.Id != 0) return BadRequest("Cannot create with Id different from zero");
            Tasks.Add(newTask);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<CWDTask> Update(int id, CWDTask newTask)
        {
            // Impossible id
            if (id == 0) return BadRequest("Impossible id (0)");
            // Id not existing
            if (!Tasks.Select(task => task.Id).Contains(id)) return NotFound($"Task with id {{{id}}} not existing");
            // Update the id of the new task
            newTask.Id = id;
            // Save the tasks
            Tasks = [.. Tasks.Select(task => task.Id == id ? newTask : task)];
            // Return the edited task
            return newTask;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            CWDTask? task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound($"Task with id {{{id}}} not existing");
            Tasks.Remove(task);
            return Ok();
        }
    }
}
