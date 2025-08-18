using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementDemo.Models;
using TaskManagementDemo.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagementDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Task
        [HttpGet]
        [Authorize] // Only authenticated users
        public async Task<IEnumerable<UserTask>> Get()
        {
            return await _taskService.GetAllTasks();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserTask>> Get(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        // POST: api/Task
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] UserTask task)
        {
            await _taskService.AddTask(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(int id, [FromBody] UserTask task)
        {
            if (id != task.Id) return BadRequest();
            await _taskService.UpdateTask(task);
            return NoContent();
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
