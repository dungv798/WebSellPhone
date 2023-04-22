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
    public class OnSalesController : Controller
    {
        private readonly WebForSellContext _context;

        public OnSalesController(WebForSellContext context)
        {
            _context = context;
        }

        // GET: OnSales
        public async Task<IActionResult> Index()
        {
              return _context.OnSale != null ? 
                          View(await _context.OnSale.ToListAsync()) :
                          Problem("Entity set 'WebForSellContext.OnSale'  is null.");
        }

        // GET: OnSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OnSale == null)
            {
                return NotFound();
            }

            var onSale = await _context.OnSale
                .FirstOrDefaultAsync(m => m.OnSaleId == id);
            if (onSale == null)
            {
                return NotFound();
            }

            return View(onSale);
        }

        // GET: OnSales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OnSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnSaleId,isOnSale,OnSaleName,OnSalePrice,OnSaleImage")] OnSale onSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(onSale);
        }

        // GET: OnSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OnSale == null)
            {
                return NotFound();
            }

            var onSale = await _context.OnSale.FindAsync(id);
            if (onSale == null)
            {
                return NotFound();
            }
            return View(onSale);
        }

        // POST: OnSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OnSaleId,OnSaleName,OnSalePrice,OnSaleImage")] OnSale onSale)
        {
            if (id != onSale.OnSaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnSaleExists(onSale.OnSaleId))
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
            return View(onSale);
        }

        // GET: OnSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OnSale == null)
            {
                return NotFound();
            }

            var onSale = await _context.OnSale
                .FirstOrDefaultAsync(m => m.OnSaleId == id);
            if (onSale == null)
            {
                return NotFound();
            }

            return View(onSale);
        }

        // POST: OnSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OnSale == null)
            {
                return Problem("Entity set 'WebForSellContext.OnSale'  is null.");
            }
            var onSale = await _context.OnSale.FindAsync(id);
            if (onSale != null)
            {
                _context.OnSale.Remove(onSale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnSaleExists(int id)
        {
          return (_context.OnSale?.Any(e => e.OnSaleId == id)).GetValueOrDefault();
        }
    }
}
