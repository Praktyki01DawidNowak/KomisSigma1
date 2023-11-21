using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KomisSigma1.Data;
using KomisSigma1.Models;
using Microsoft.AspNetCore.Authorization;


namespace KomisSigma1.Controllers
{
    public class SamochodziksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SamochodziksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Samochodziks


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Samochodzik.Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajNadwozia).Include(s => s.RodzajPaliwa);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexMniejsze10000()
        {
            var applicationDbContext = _context.Samochodzik.Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajNadwozia).Include(s => s.RodzajPaliwa)
            .Where(p => p.Cena < 10000);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> IndexMiedzy10001A50000()
        {
            var applicationDbContext = _context.Samochodzik.Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajNadwozia).Include(s => s.RodzajPaliwa)
            .Where(p => p.Cena > 10000 && p.Cena < 50000);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexWiecej50000()
        {
            var applicationDbContext = _context.Samochodzik.Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajNadwozia).Include(s => s.RodzajPaliwa)
            .Where(p => p.Cena > 50000);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Samochodziks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Samochodzik == null)
            {
                return NotFound();
            }

            var samochodzik = await _context.Samochodzik
                .Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.RodzajNadwozia)
                .Include(s => s.RodzajPaliwa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (samochodzik == null)
            {
                return NotFound();
            }

            return View(samochodzik);
        }

        // GET: Samochodziks/Create

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["MarkaID"] = new SelectList(_context.Set<Marka>(), "ID", "Nazwa");
            ViewData["ModelID"] = new SelectList(_context.Set<Model>(), "ID", "Nazwa");
            ViewData["RodzajNadwoziaID"] = new SelectList(_context.Set<RodzajNadwozia>(), "ID", "Rodzaj");
            ViewData["RodzajPaliwaID"] = new SelectList(_context.Set<RodzajPaliwa>(), "ID", "Rodzaj");
            return View();
        }

        // POST: Samochodziks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MarkaID,ModelID,RodzajNadwoziaID,RodzajPaliwaID,Kolor,PojemnośćSilnika,Przebieg,VIN,Cena")] Samochodzik samochodzik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samochodzik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarkaID"] = new SelectList(_context.Set<Marka>(), "ID", "ID", samochodzik.MarkaID);
            ViewData["ModelID"] = new SelectList(_context.Set<Model>(), "ID", "ID", samochodzik.ModelID);
            ViewData["RodzajNadwoziaID"] = new SelectList(_context.Set<RodzajNadwozia>(), "ID", "ID", samochodzik.RodzajNadwoziaID);
            ViewData["RodzajPaliwaID"] = new SelectList(_context.Set<RodzajPaliwa>(), "ID", "ID", samochodzik.RodzajPaliwaID);
            return View(samochodzik);
        }

        // GET: Samochodziks/Edit/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Samochodzik == null)
            {
                return NotFound();
            }

            var samochodzik = await _context.Samochodzik.FindAsync(id);
            if (samochodzik == null)
            {
                return NotFound();
            }
            ViewData["MarkaID"] = new SelectList(_context.Set<Marka>(), "ID", "Nazwa", samochodzik.MarkaID);
            ViewData["ModelID"] = new SelectList(_context.Set<Model>(), "ID", "Nazwa", samochodzik.ModelID);
            ViewData["RodzajNadwoziaID"] = new SelectList(_context.Set<RodzajNadwozia>(), "ID", "Rodzaj", samochodzik.RodzajNadwoziaID);
            ViewData["RodzajPaliwaID"] = new SelectList(_context.Set<RodzajPaliwa>(), "ID", "Rodzaj", samochodzik.RodzajPaliwaID);
            return View(samochodzik);
        }

        // POST: Samochodziks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MarkaID,ModelID,RodzajNadwoziaID,RodzajPaliwaID,Kolor,PojemnośćSilnika,Przebieg,VIN,Cena")] Samochodzik samochodzik)
        {
            if (id != samochodzik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samochodzik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamochodzikExists(samochodzik.ID))
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
            ViewData["MarkaID"] = new SelectList(_context.Set<Marka>(), "ID", "ID", samochodzik.MarkaID);
            ViewData["ModelID"] = new SelectList(_context.Set<Model>(), "ID", "ID", samochodzik.ModelID);
            ViewData["RodzajNadwoziaID"] = new SelectList(_context.Set<RodzajNadwozia>(), "ID", "ID", samochodzik.RodzajNadwoziaID);
            ViewData["RodzajPaliwaID"] = new SelectList(_context.Set<RodzajPaliwa>(), "ID", "ID", samochodzik.RodzajPaliwaID);
            return View(samochodzik);
        }

        // GET: Samochodziks/Delete/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Samochodzik == null)
            {
                return NotFound();
            }

            var samochodzik = await _context.Samochodzik
                .Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.RodzajNadwozia)
                .Include(s => s.RodzajPaliwa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (samochodzik == null)
            {
                return NotFound();
            }

            return View(samochodzik);
        }

        // POST: Samochodziks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Samochodzik == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Samochodzik'  is null.");
            }
            var samochodzik = await _context.Samochodzik.FindAsync(id);
            if (samochodzik != null)
            {
                _context.Samochodzik.Remove(samochodzik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamochodzikExists(int id)
        {
            return (_context.Samochodzik?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}