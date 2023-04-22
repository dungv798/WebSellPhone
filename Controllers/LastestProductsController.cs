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
    public class LastestProductsController : Controller
    {
        private readonly WebForSellContext _context;

        public LastestProductsController(WebForSellContext context)
        {
            _context = context;
        }

        // GET: LastestProducts
        public async Task<IActionResult> Index()
        {
              return _context.LastestProduct != null ? 
                          View(await _context.LastestProduct.ToListAsync()) :
                          Problem("Entity set 'WebForSellContext.LastestProduct'  is null.");
        }

        // GET: LastestProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LastestProduct == null)
            {
                return NotFound();
            }

            var lastestProduct = await _context.LastestProduct
                .FirstOrDefaultAsync(m => m.LastestProductId == id);
            if (lastestProduct == null)
            {
                return NotFound();
            }

            return View(lastestProduct);
        }

        // GET: LastestProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LastestProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastestProductId,isLasted,LastestProductName,LastestProductPrice,LastestProductImage")] LastestProduct lastestProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lastestProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lastestProduct);
        }

        // GET: LastestProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LastestProduct == null)
            {
                return NotFound();
            }

            var lastestProduct = await _context.LastestProduct.FindAsync(id);
            if (lastestProduct == null)
            {
                return NotFound();
            }
            return View(lastestProduct);
        }

        // POST: LastestProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LastestProductId,LastestProductName,LastestProductPrice,LastestProductImage")] LastestProduct lastestProduct)
        {
            if (id != lastestProduct.LastestProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lastestProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LastestProductExists(lastestProduct.LastestProductId))
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
            return View(lastestProduct);
        }

        // GET: LastestProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LastestProduct == null)
            {
                return NotFound();
            }

            var lastestProduct = await _context.LastestProduct
                .FirstOrDefaultAsync(m => m.LastestProductId == id);
            if (lastestProduct == null)
            {
                return NotFound();
            }

            return View(lastestProduct);
        }

        // POST: LastestProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LastestProduct == null)
            {
                return Problem("Entity set 'WebForSellContext.LastestProduct'  is null.");
            }
            var lastestProduct = await _context.LastestProduct.FindAsync(id);
            if (lastestProduct != null)
            {
                _context.LastestProduct.Remove(lastestProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LastestProductExists(int id)
        {
          return (_context.LastestProduct?.Any(e => e.LastestProductId == id)).GetValueOrDefault();
        }
    }
}
