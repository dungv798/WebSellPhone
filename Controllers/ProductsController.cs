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
    public class ProductsController : Controller
    {
        private readonly WebForSellContext _context;

        public ProductsController(WebForSellContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var webForSellContext = _context.Product.Include(p => p.Brand).Include(p => p.Category);
            return View(await webForSellContext.ToListAsync());
        }
        public async Task<IActionResult> ProductByCategory(int catId)
        {
            var webForSellContext = _context.Product.Include(p => p.Brand).Include(p => p.Category).Where(p=>p.CategoryId == catId);
            return View(await webForSellContext.ToListAsync());
        }
        public async Task<IActionResult> ProductDetails(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandDescription");
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId");
            ViewData["DofweekId"] = new SelectList(_context.Dofweek, "DofweekId", "isDoTW");
            ViewData["LastestProductId"] = new SelectList(_context.LastestProduct, "LastestProductId", "isLasted");
            ViewData["NewArrId"] = new SelectList(_context.NewArr, "NewArrId", "isArr");
            ViewData["OnSaleId"] = new SelectList(_context.OnSale, "OnSaleId", "isOnSale");
            ViewData["TopSellId"] = new SelectList(_context.TopSell, "TopSellId", "isTop");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductPrice,ProductDescription,ProductQuantity,ProductImage,ProductImage2,CategoryId,BrandId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandDescription", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["isDoTW"] = new SelectList(_context.Dofweek, "DofweekId", "isDoTW", product.isDoTW);
            ViewData["isLasted"] = new SelectList(_context.LastestProduct, "LastestProductId", "isLasted", product.isLasted);
            ViewData["isArr"] = new SelectList(_context.NewArr, "NewArrId", "isArr", product.isArr);
            ViewData["isOnSale"] = new SelectList(_context.Category, "OnSaleId", "isOnSale", product.isOnSale);
            ViewData["isTop"] = new SelectList(_context.Brand, "TopSellId", "isTop", product.isTop);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandDescription", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["isDoTW"] = new SelectList(_context.Dofweek, "isDoTW", "isDoTW", product.isDoTW);
            ViewData["isLasted"] = new SelectList(_context.LastestProduct, "isLasted", "isLasted", product.isLasted);
            ViewData["isArr"] = new SelectList(_context.NewArr, "isArr", "isArr", product.isArr);
            ViewData["isOnSale"] = new SelectList(_context.OnSale, "isOnSale", "isOnSale", product.isOnSale);
            ViewData["isTop"] = new SelectList(_context.TopSell, "isTop", "isTop", product.isTop);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductPrice,ProductDescription,ProductQuantity,ProductImage,ProductImage2,CategoryId,BrandId,isDoTW,isLasted,isArr,isOnSale,isTop")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandDescription", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["isDoTW"] = new SelectList(_context.Dofweek, "isDoTW", "isDoTW", product.isDoTW);
            ViewData["isLasted"] = new SelectList(_context.LastestProduct, "isLasted", "isLasted", product.isLasted);
            ViewData["isArr"] = new SelectList(_context.NewArr, "isArr", "isArr", product.isArr);
            ViewData["isOnSale"] = new SelectList(_context.OnSale, "isOnSale", "isOnSale", product.isOnSale);
            ViewData["isTop"] = new SelectList(_context.TopSell, "isTop", "isTop", product.isTop);

            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'WebForSellContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
