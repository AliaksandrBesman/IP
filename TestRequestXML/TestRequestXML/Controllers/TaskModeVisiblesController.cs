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
    public class TaskModeVisiblesController : ControllerBase
    {
        private readonly graduateprojectsContext _context;

        public TaskModeVisiblesController(graduateprojectsContext context)
        {
            _context = context;
        }

        // GET: api/TaskModeVisibles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModeVisible>>> GetTaskModeVisible()
        {
            return await _context.TaskModeVisible.ToListAsync();
        }

        // GET: api/TaskModeVisibles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModeVisible>> GetTaskModeVisible(int id)
        {
            var taskModeVisible = await _context.TaskModeVisible.FindAsync(id);

            if (taskModeVisible == null)
            {
                return NotFound();
            }

            return taskModeVisible;
        }

        // PUT: api/TaskModeVisibles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskModeVisible(int id, TaskModeVisible taskModeVisible)
        {
            if (id != taskModeVisible.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskModeVisible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskModeVisibleExists(id))
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

        // POST: api/TaskModeVisibles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskModeVisible>> PostTaskModeVisible(TaskModeVisible taskModeVisible)
        {
            _context.TaskModeVisible.Add(taskModeVisible);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskModeVisible", new { id = taskModeVisible.Id }, taskModeVisible);
        }

        // DELETE: api/TaskModeVisibles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModeVisible>> DeleteTaskModeVisible(int id)
        {
            var taskModeVisible = await _context.TaskModeVisible.FindAsync(id);
            if (taskModeVisible == null)
            {
                return NotFound();
            }

            _context.TaskModeVisible.Remove(taskModeVisible);
            await _context.SaveChangesAsync();

            return taskModeVisible;
        }

        private bool TaskModeVisibleExists(int id)
        {
            return _context.TaskModeVisible.Any(e => e.Id == id);
        }
    }
}
