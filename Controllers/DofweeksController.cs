using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebForSell.Data;
using WebForSell.Models;

namespace WebForSell.Controllers
{
    public class DofweeksController : Controller
    {
        private readonly WebForSellContext _context;

        public DofweeksController(WebForSellContext context)
        {
            _context = context;
        }

        // GET: Dofweeks
        public async Task<IActionResult> Index()
        {
              return _context.Dofweek != null ? 
                          View(await _context.Dofweek.ToListAsync()) :
                          Problem("Entity set 'WebForSellContext.Dofweek'  is null.");
        }

        // GET: Dofweeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dofweek == null)
            {
                return NotFound();
            }

            var dofweek = await _context.Dofweek
                .FirstOrDefaultAsync(m => m.DofweekId == id);
            if (dofweek == null)
            {
                return NotFound();
            }

            return View(dofweek);
        }

        // GET: Dofweeks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dofweeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DofweekId,isDoTW,DofweekName,DofweekPrice,DofweekDescription,DofweekImage")] Dofweek dofweek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dofweek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dofweek);
        }

        // GET: Dofweeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dofweek == null)
            {
                return NotFound();
            }

            var dofweek = await _context.Dofweek.FindAsync(id);
            if (dofweek == null)
            {
                return NotFound();
            }
            return View(dofweek);
        }

        // POST: Dofweeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DofweekId,isDoTW,DofweekName,DofweekPrice,DofweekDescription,DofweekImage")] Dofweek dofweek)
        {
            if (id != dofweek.DofweekId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dofweek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DofweekExists(dofweek.DofweekId))
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
            return View(dofweek);
        }

        // GET: Dofweeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dofweek == null)
            {
                return NotFound();
            }

            var dofweek = await _context.Dofweek
                .FirstOrDefaultAsync(m => m.DofweekId == id);
            if (dofweek == null)
            {
                return NotFound();
            }

            return View(dofweek);
        }

        // POST: Dofweeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dofweek == null)
            {
                return Problem("Entity set 'WebForSellContext.Dofweek'  is null.");
            }
            var dofweek = await _context.Dofweek.FindAsync(id);
            if (dofweek != null)
            {
                _context.Dofweek.Remove(dofweek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DofweekExists(int id)
        {
          return (_context.Dofweek?.Any(e => e.DofweekId == id)).GetValueOrDefault();
        }
    }
}
