using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KomisSigma1.Data;
using KomisSigma1.Models;


namespace KomisSigma1.Controllers
{
    public class RodzajPaliwasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RodzajPaliwasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RodzajPaliwas
        public async Task<IActionResult> Index()
        {
            return _context.RodzajPaliwa != null ?
                        View(await _context.RodzajPaliwa.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.RodzajPaliwa'  is null.");
        }

        // GET: RodzajPaliwas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RodzajPaliwa == null)
            {
                return NotFound();
            }

            var rodzajPaliwa = await _context.RodzajPaliwa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rodzajPaliwa == null)
            {
                return NotFound();
            }

            return View(rodzajPaliwa);
        }

        // GET: RodzajPaliwas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RodzajPaliwas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Rodzaj,Opis")] RodzajPaliwa rodzajPaliwa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rodzajPaliwa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rodzajPaliwa);
        }

        // GET: RodzajPaliwas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RodzajPaliwa == null)
            {
                return NotFound();
            }

            var rodzajPaliwa = await _context.RodzajPaliwa.FindAsync(id);
            if (rodzajPaliwa == null)
            {
                return NotFound();
            }
            return View(rodzajPaliwa);
        }

        // POST: RodzajPaliwas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Rodzaj,Opis")] RodzajPaliwa rodzajPaliwa)
        {
            if (id != rodzajPaliwa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodzajPaliwa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodzajPaliwaExists(rodzajPaliwa.ID))
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
            return View(rodzajPaliwa);
        }

        // GET: RodzajPaliwas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RodzajPaliwa == null)
            {
                return NotFound();
            }

            var rodzajPaliwa = await _context.RodzajPaliwa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rodzajPaliwa == null)
            {
                return NotFound();
            }

            return View(rodzajPaliwa);
        }

        // POST: RodzajPaliwas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RodzajPaliwa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RodzajPaliwa'  is null.");
            }
            var rodzajPaliwa = await _context.RodzajPaliwa.FindAsync(id);
            if (rodzajPaliwa != null)
            {
                _context.RodzajPaliwa.Remove(rodzajPaliwa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodzajPaliwaExists(int id)
        {
            return (_context.RodzajPaliwa?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}