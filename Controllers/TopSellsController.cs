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
    public class TopSellsController : Controller
    {
        private readonly WebForSellContext _context;

        public TopSellsController(WebForSellContext context)
        {
            _context = context;
        }

        // GET: TopSells
        public async Task<IActionResult> Index()
        {
              return _context.TopSell != null ? 
                          View(await _context.TopSell.ToListAsync()) :
                          Problem("Entity set 'WebForSellContext.TopSell'  is null.");
        }

        // GET: TopSells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TopSell == null)
            {
                return NotFound();
            }

            var topSell = await _context.TopSell
                .FirstOrDefaultAsync(m => m.TopSellId == id);
            if (topSell == null)
            {
                return NotFound();
            }

            return View(topSell);
        }

        // GET: TopSells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopSells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TopSellId,isTop,TopSellName,TopSellPrice,TopSellImage")] TopSell topSell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topSell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topSell);
        }

        // GET: TopSells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TopSell == null)
            {
                return NotFound();
            }

            var topSell = await _context.TopSell.FindAsync(id);
            if (topSell == null)
            {
                return NotFound();
            }
            return View(topSell);
        }

        // POST: TopSells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TopSellId,isTop,TopSellName,TopSellPrice,TopSellImage")] TopSell topSell)
        {
            if (id != topSell.TopSellId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topSell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopSellExists(topSell.TopSellId))
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
            return View(topSell);
        }

        // GET: TopSells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TopSell == null)
            {
                return NotFound();
            }

            var topSell = await _context.TopSell
                .FirstOrDefaultAsync(m => m.TopSellId == id);
            if (topSell == null)
            {
                return NotFound();
            }

            return View(topSell);
        }

        // POST: TopSells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TopSell == null)
            {
                return Problem("Entity set 'WebForSellContext.TopSell'  is null.");
            }
            var topSell = await _context.TopSell.FindAsync(id);
            if (topSell != null)
            {
                _context.TopSell.Remove(topSell);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopSellExists(int id)
        {
          return (_context.TopSell?.Any(e => e.TopSellId == id)).GetValueOrDefault();
        }
    }
}
