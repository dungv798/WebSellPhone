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
    public class HomeProductsController : Controller
    {
        private readonly WebForSellContext _context;

        public HomeProductsController(WebForSellContext context)
        {
            _context = context;
        }

        // GET: HomeProducts
        public async Task<IActionResult> Index()
        {
            var webForSellContext = _context.HomeProduct.Include(h => h.Dofweek).Include(h => h.LastestProduct).Include(h => h.NewArr).Include(h => h.OnSale).Include(h => h.TopSell);
            return View(await webForSellContext.ToListAsync());
        }

        // GET: HomeProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HomeProduct == null)
            {
                return NotFound();
            }

            var homeProduct = await _context.HomeProduct
                .Include(h => h.Dofweek)
                .Include(h => h.LastestProduct)
                .Include(h => h.NewArr)
                .Include(h => h.OnSale)
                .Include(h => h.TopSell)
                .FirstOrDefaultAsync(m => m.HomeProductId == id);
            if (homeProduct == null)
            {
                return NotFound();
            }

            return View(homeProduct);
        }

        // GET: HomeProducts/Create
        public IActionResult Create()
        {
            ViewData["DofweekId"] = new SelectList(_context.Dofweek, "DofweekId", "DofweekName");
            ViewData["LastestProductId"] = new SelectList(_context.LastestProduct, "LastestProductId", "LastestProductName");
            ViewData["NewArrId"] = new SelectList(_context.NewArr, "NewArrId", "NewArrName");
            ViewData["OnSaleId"] = new SelectList(_context.OnSale, "OnSaleId", "OnSaleName");
            ViewData["TopSellId"] = new SelectList(_context.TopSell, "TopSellId", "TopSellName");
            return View();
        }

        // POST: HomeProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeProductId,HomeProductName,NewArrId,TopSellId,OnSaleId,LastestProductId,DofweekId")] HomeProduct homeProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DofweekId"] = new SelectList(_context.Dofweek, "DofweekId", "DofweekName", homeProduct.DofweekId);
            ViewData["LastestProductId"] = new SelectList(_context.LastestProduct, "LastestProductId", "LastestProductName", homeProduct.LastestProductId);
            ViewData["NewArrId"] = new SelectList(_context.NewArr, "NewArrId", "NewArrName", homeProduct.NewArrId);
            ViewData["OnSaleId"] = new SelectList(_context.OnSale, "OnSaleId", "OnSaleName", homeProduct.OnSaleId);
            ViewData["TopSellId"] = new SelectList(_context.TopSell, "TopSellId", "TopSellName", homeProduct.TopSellId);
            return View(homeProduct);
        }

        // GET: HomeProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HomeProduct == null)
            {
                return NotFound();
            }

            var homeProduct = await _context.HomeProduct.FindAsync(id);
            if (homeProduct == null)
            {
                return NotFound();
            }
            ViewData["DofweekId"] = new SelectList(_context.Dofweek, "DofweekId", "DofweekName", homeProduct.DofweekId);
            ViewData["LastestProductId"] = new SelectList(_context.LastestProduct, "LastestProductId", "LastestProductName", homeProduct.LastestProductId);
            ViewData["NewArrId"] = new SelectList(_context.NewArr, "NewArrId", "NewArrName", homeProduct.NewArrId);
            ViewData["OnSaleId"] = new SelectList(_context.OnSale, "OnSaleId", "OnSaleName", homeProduct.OnSaleId);
            ViewData["TopSellId"] = new SelectList(_context.TopSell, "TopSellId", "TopSellName", homeProduct.TopSellId);
            return View(homeProduct);
        }

        // POST: HomeProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HomeProductId,HomeProductName,NewArrId,TopSellId,OnSaleId,LastestProductId,DofweekId")] HomeProduct homeProduct)
        {
            if (id != homeProduct.HomeProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeProductExists(homeProduct.HomeProductId))
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
            ViewData["DofweekId"] = new SelectList(_context.Dofweek, "DofweekId", "DofweekName", homeProduct.DofweekId);
            ViewData["LastestProductId"] = new SelectList(_context.LastestProduct, "LastestProductId", "LastestProductName", homeProduct.LastestProductId);
            ViewData["NewArrId"] = new SelectList(_context.NewArr, "NewArrId", "NewArrName", homeProduct.NewArrId);
            ViewData["OnSaleId"] = new SelectList(_context.OnSale, "OnSaleId", "OnSaleName", homeProduct.OnSaleId);
            ViewData["TopSellId"] = new SelectList(_context.TopSell, "TopSellId", "TopSellName", homeProduct.TopSellId);
            return View(homeProduct);
        }

        // GET: HomeProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HomeProduct == null)
            {
                return NotFound();
            }

            var homeProduct = await _context.HomeProduct
                .Include(h => h.Dofweek)
                .Include(h => h.LastestProduct)
                .Include(h => h.NewArr)
                .Include(h => h.OnSale)
                .Include(h => h.TopSell)
                .FirstOrDefaultAsync(m => m.HomeProductId == id);
            if (homeProduct == null)
            {
                return NotFound();
            }

            return View(homeProduct);
        }

        // POST: HomeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HomeProduct == null)
            {
                return Problem("Entity set 'WebForSellContext.HomeProduct'  is null.");
            }
            var homeProduct = await _context.HomeProduct.FindAsync(id);
            if (homeProduct != null)
            {
                _context.HomeProduct.Remove(homeProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeProductExists(int id)
        {
          return (_context.HomeProduct?.Any(e => e.HomeProductId == id)).GetValueOrDefault();
        }
    }
}
