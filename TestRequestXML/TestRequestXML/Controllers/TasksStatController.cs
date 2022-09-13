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
    public class TasksStatController : ControllerBase
    {
        private readonly graduateprojectsContext _context;

        public TasksStatController(graduateprojectsContext context)
        {
            _context = context;
        }
        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TasksStageStat>>> GetTasks()
        {
            return await _context.TasksStageStat.ToListAsync();
        }

        // GET api/<TasksStatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TasksStatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TasksStatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksStatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
