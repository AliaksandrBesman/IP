using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LW8aMVC_API.Models;

namespace LW8aMVC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneNumbersAPIController : ControllerBase
    {
        private readonly TelephoneNumberContext _context;

        public TelephoneNumbersAPIController(TelephoneNumberContext context)
        {
            _context = context;
        }

        // GET: api/TelephoneNumbersAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelephoneNumber>>> GettelephoneNumbers()
        {
            return await _context.telephoneNumbers.ToListAsync();
        }

        // GET: api/TelephoneNumbersAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TelephoneNumber>> GetTelephoneNumber(int id)
        {
            var telephoneNumber = await _context.telephoneNumbers.FindAsync(id);

            if (telephoneNumber == null)
            {
                return NotFound();
            }

            return telephoneNumber;
        }

        // PUT: api/TelephoneNumbersAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelephoneNumber(int id, TelephoneNumber telephoneNumber)
        {
            if (id != telephoneNumber.Id)
            {
                return BadRequest();
            }

            _context.Entry(telephoneNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelephoneNumberExists(id))
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

        // POST: api/TelephoneNumbersAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TelephoneNumber>> PostTelephoneNumber(TelephoneNumber telephoneNumber)
        {
            _context.telephoneNumbers.Add(telephoneNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelephoneNumber", new { id = telephoneNumber.Id }, telephoneNumber);
        }

        // DELETE: api/TelephoneNumbersAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TelephoneNumber>> DeleteTelephoneNumber(int id)
        {
            var telephoneNumber = await _context.telephoneNumbers.FindAsync(id);
            if (telephoneNumber == null)
            {
                return NotFound();
            }

            _context.telephoneNumbers.Remove(telephoneNumber);
            await _context.SaveChangesAsync();

            return telephoneNumber;
        }

        private bool TelephoneNumberExists(int id)
        {
            return _context.telephoneNumbers.Any(e => e.Id == id);
        }
    }
}
