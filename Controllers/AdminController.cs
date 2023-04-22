using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebForSell.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
