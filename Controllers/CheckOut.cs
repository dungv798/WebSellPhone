using Microsoft.AspNetCore.Mvc;

namespace WebForSell.Controllers
{
    public class CheckOut : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
