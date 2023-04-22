using Microsoft.AspNetCore.Mvc;
using WebForSell.Data;

namespace WebForSell.Models
{
    public class Navbar: ViewComponent
    {
        private readonly WebForSellContext _context;

        public Navbar(WebForSellContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Category.ToList());
        }
    }
}
