using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TestRequestXML.Models;

namespace TestRequestXML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly graduateprojectsContext _context;

        public UsersController(graduateprojectsContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsersDetails>> GetUser(int id)
        {
            var users = await  _context.UsersDetails.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }
        // GET: api/Users/5
        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<IEnumerable<UsersInfo>>> GetUsers(int id)
        {
            var users = await _context.UsersInfo.Where(x=>x.ManagerId == id).ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // GET: api/Users/5
        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetAssignedStudents(int id)
        {
            var users = await _context.Users.Include(t=>t.UserDetails).Where(x => x.ManagerId == id && x.RoleId == 4).ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }
        // GET: api/Users/5
        [HttpGet("{login:alpha}")]
        public async Task<ActionResult<Users>> GetUser(string login)
        {
            var users = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            Users existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == users.Login);
            if (existingUser != null)
            {
                return BadRequest("This login already exists");
            }

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> AddAssignedUser(JObject data)
        {
            int userId = data["userId"].ToObject<int>();
            int assignedUserId = data["assignedUserId"].ToObject<int>();
            Users users = _context.Users.Find(assignedUserId);
            users.ManagerId = userId;
            _context.Entry(users).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NotFound();
            }

            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
