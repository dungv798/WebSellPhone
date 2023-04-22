using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebForSell.Data;
using WebForSell.Models;

namespace WebForSell.Controllers
{
	public class HomeController : Controller
	{
        private readonly WebForSellContext _context;

        public HomeController(WebForSellContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{

            var _Product = _context.Product.Include(h => h.Dofweek).Include(h => h.LastestProduct).Include(h => h.NewArr).Include(h => h.OnSale).Include(h => h.TopSell);
            return View(_Product.ToList());
        }
       

        public IActionResult About()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}
        public IActionResult Product()
        {
            var _product = _context.Product.Include(p => p.Brand).Include(p => p.Category);
            return View(_product.ToList());
        }
        public IActionResult New()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}