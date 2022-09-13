using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestRequestXML.Models;

namespace TestRequestXML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskPrioritiesController : ControllerBase
    {
        private readonly graduateprojectsContext _context;

        public TaskPrioritiesController(graduateprojectsContext context)
        {
            _context = context;
        }

        // GET: api/TaskPriorities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskPriority>>> GetTaskPriority()
        {
            return await _context.TaskPriority.ToListAsync();
        }

        // GET: api/TaskPriorities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskPriority>> GetTaskPriority(int id)
        {
            var taskPriority = await _context.TaskPriority.FindAsync(id);

            if (taskPriority == null)
            {
                return NotFound();
            }

            return taskPriority;
        }

        // PUT: api/TaskPriorities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskPriority(int id, TaskPriority taskPriority)
        {
            if (id != taskPriority.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskPriority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskPriorityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskPriorities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskPriority>> PostTaskPriority(TaskPriority taskPriority)
        {
            _context.TaskPriority.Add(taskPriority);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskPriority", new { id = taskPriority.Id }, taskPriority);
        }

        // DELETE: api/TaskPriorities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskPriority>> DeleteTaskPriority(int id)
        {
            var taskPriority = await _context.TaskPriority.FindAsync(id);
            if (taskPriority == null)
            {
                return NotFound();
            }

            _context.TaskPriority.Remove(taskPriority);
            await _context.SaveChangesAsync();

            return taskPriority;
        }

        private bool TaskPriorityExists(int id)
        {
            return _context.TaskPriority.Any(e => e.Id == id);
        }
    }
}
