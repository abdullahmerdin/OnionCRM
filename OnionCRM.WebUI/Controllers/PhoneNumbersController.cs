using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnionCRM.Core.Domain;
using OnionCRM.Persistance.Context;


namespace OnionCRM.WebUI.Controllers
{
    [AllowAnonymous]
    public class PhoneNumbersController : Controller
    {
        private readonly OnionProjectContext _context;

        public PhoneNumbersController(OnionProjectContext context)
        {
            _context = context;
        }

        // GET: PhoneNumbers
        public async Task<IActionResult> Index()
        {
              return _context.PhoneNumbers != null ? 
                          View(await _context.PhoneNumbers.ToListAsync()) :
                          Problem("Entity set 'OnionProjectContext.PhoneNumbers'  is null.");
        }

        // GET: PhoneNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhoneNumbers == null)
            {
                return NotFound();
            }

            var phoneNumber = await _context.PhoneNumbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneNumber == null)
            {
                return NotFound();
            }

            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,User")] PhoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhoneNumbers == null)
            {
                return NotFound();
            }

            var phoneNumber = await _context.PhoneNumbers.FindAsync(id);
            if (phoneNumber == null)
            {
                return NotFound();
            }
            return View(phoneNumber);
        }

        // POST: PhoneNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,User")] PhoneNumber phoneNumber)
        {
            if (id != phoneNumber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneNumberExists(phoneNumber.Id))
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
            return View(phoneNumber);
        }

        // GET: PhoneNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhoneNumbers == null)
            {
                return NotFound();
            }

            var phoneNumber = await _context.PhoneNumbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneNumber == null)
            {
                return NotFound();
            }

            return View(phoneNumber);
        }

        // POST: PhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhoneNumbers == null)
            {
                return Problem("Entity set 'OnionProjectContext.PhoneNumbers'  is null.");
            }
            var phoneNumber = await _context.PhoneNumbers.FindAsync(id);
            if (phoneNumber != null)
            {
                _context.PhoneNumbers.Remove(phoneNumber);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneNumberExists(int id)
        {
          return (_context.PhoneNumbers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
