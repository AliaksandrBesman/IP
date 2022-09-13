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
    public class NoticesController : ControllerBase
    {
        private readonly graduateprojectsContext _context;

        public NoticesController(graduateprojectsContext context)
        {
            _context = context;
        }

        // GET: api/Notices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notices>>> GetNotices()
        {
            return await _context.Notices.ToListAsync();
        }

        // GET: api/Notices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notices>> GetNotices(int id)
        {
            var notices = await _context.Notices.FindAsync(id);

            if (notices == null)
            {
                return NotFound();
            }

            return notices;
        }

        // GET: api/Notices/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<NoticesList>>> GetNoticesByUserId(int id)
        {
            var notices = await _context.NoticesList.Where(x=>x.NoticeOwner == id).ToListAsync();

            if (notices == null)
            {
                return NotFound();
            }

            return notices;
        }
        // PUT: api/Notices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotices(int id, Notices notices)
        {
            if (id != notices.Id)
            {
                return BadRequest();
            }

            _context.Entry(notices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticesExists(id))
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

        // POST: api/Notices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Notices>> PostNotices(Notices notices)
        {
            _context.Notices.Add(notices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotices", new { id = notices.Id }, notices);
        }

        // DELETE: api/Notices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notices>> DeleteNotices(int id)
        {
            var notices = await _context.Notices.FindAsync(id);
            if (notices == null)
            {
                return NotFound();
            }

            _context.Notices.Remove(notices);
            await _context.SaveChangesAsync();

            return notices;
        }

        private bool NoticesExists(int id)
        {
            return _context.Notices.Any(e => e.Id == id);
        }
    }
}
