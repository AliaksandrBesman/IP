using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LW8a.Models;

namespace LW8a.Controllers
{
    public class TelephoneNumbersController : Controller
    {
        private readonly TelephoneNumberContext _context;

        public TelephoneNumbersController(TelephoneNumberContext context)
        {
            _context = context;
        }

        // GET: TelephoneNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.telephoneNumbers.ToListAsync());
        }

        // GET: TelephoneNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telephoneNumber = await _context.telephoneNumbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telephoneNumber == null)
            {
                return NotFound();
            }

            return View(telephoneNumber);
        }

        // GET: TelephoneNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TelephoneNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber")] TelephoneNumber telephoneNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telephoneNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telephoneNumber);
        }

        // GET: TelephoneNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telephoneNumber = await _context.telephoneNumbers.FindAsync(id);
            if (telephoneNumber == null)
            {
                return NotFound();
            }
            return View(telephoneNumber);
        }

        // POST: TelephoneNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber")] TelephoneNumber telephoneNumber)
        {
            if (id != telephoneNumber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telephoneNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelephoneNumberExists(telephoneNumber.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(telephoneNumber);
        }

        // GET: TelephoneNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telephoneNumber = await _context.telephoneNumbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telephoneNumber == null)
            {
                return NotFound();
            }

            return View(telephoneNumber);
        }

        // POST: TelephoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telephoneNumber = await _context.telephoneNumbers.FindAsync(id);
            _context.telephoneNumbers.Remove(telephoneNumber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelephoneNumberExists(int id)
        {
            return _context.telephoneNumbers.Any(e => e.Id == id);
        }
    }
}
