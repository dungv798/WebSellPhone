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
    public class NewArrsController : Controller
    {
        private readonly WebForSellContext _context;

        public NewArrsController(WebForSellContext context)
        {
            _context = context;
        }

        // GET: NewArrs
        public async Task<IActionResult> Index()
        {
              return _context.NewArr != null ? 
                          View(await _context.NewArr.ToListAsync()) :
                          Problem("Entity set 'WebForSellContext.NewArr'  is null.");
        }

        // GET: NewArrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NewArr == null)
            {
                return NotFound();
            }

            var newArr = await _context.NewArr
                .FirstOrDefaultAsync(m => m.NewArrId == id);
            if (newArr == null)
            {
                return NotFound();
            }

            return View(newArr);
        }

        // GET: NewArrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewArrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewArrId,isArr,NewArrName,NewArrPrice,NewArrImage")] NewArr newArr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newArr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newArr);
        }

        // GET: NewArrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NewArr == null)
            {
                return NotFound();
            }

            var newArr = await _context.NewArr.FindAsync(id);
            if (newArr == null)
            {
                return NotFound();
            }
            return View(newArr);
        }

        // POST: NewArrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewArrId,NewArrName,NewArrPrice,NewArrImage")] NewArr newArr)
        {
            if (id != newArr.NewArrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newArr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewArrExists(newArr.NewArrId))
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
            return View(newArr);
        }

        // GET: NewArrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NewArr == null)
            {
                return NotFound();
            }

            var newArr = await _context.NewArr
                .FirstOrDefaultAsync(m => m.NewArrId == id);
            if (newArr == null)
            {
                return NotFound();
            }

            return View(newArr);
        }

        // POST: NewArrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NewArr == null)
            {
                return Problem("Entity set 'WebForSellContext.NewArr'  is null.");
            }
            var newArr = await _context.NewArr.FindAsync(id);
            if (newArr != null)
            {
                _context.NewArr.Remove(newArr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewArrExists(int id)
        {
          return (_context.NewArr?.Any(e => e.NewArrId == id)).GetValueOrDefault();
        }
    }
}
