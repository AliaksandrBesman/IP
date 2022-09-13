using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestRequestXML.Models;
using TaskStatus = TestRequestXML.Models.TaskStatus;

namespace TestRequestXML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly graduateprojectsContext _context;

        public TaskStatusController(graduateprojectsContext context)
        {
            _context = context;
        }

        // GET: api/TaskStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskStatus>>> GetTaskStatus()
        {
            return await _context.TaskStatus.ToListAsync();
        }

        // GET: api/TaskStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskStatus>> GetTaskStatus(int id)
        {
            var taskStatus = await _context.TaskStatus.FindAsync(id);

            if (taskStatus == null)
            {
                return NotFound();
            }

            return taskStatus;
        }

        // PUT: api/TaskStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskStatus(int id, TaskStatus taskStatus)
        {
            if (id != taskStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskStatusExists(id))
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

        // POST: api/TaskStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskStatus>> PostTaskStatus(TaskStatus taskStatus)
        {
            _context.TaskStatus.Add(taskStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskStatus", new { id = taskStatus.Id }, taskStatus);
        }

        // DELETE: api/TaskStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskStatus>> DeleteTaskStatus(int id)
        {
            var taskStatus = await _context.TaskStatus.FindAsync(id);
            if (taskStatus == null)
            {
                return NotFound();
            }

            _context.TaskStatus.Remove(taskStatus);
            await _context.SaveChangesAsync();

            return taskStatus;
        }

        private bool TaskStatusExists(int id)
        {
            return _context.TaskStatus.Any(e => e.Id == id);
        }
    }
}
