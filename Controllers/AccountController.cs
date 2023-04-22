using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebForSell.Models;
using WebForSell.Data;

namespace WebForSell.Controllers
{
    public class AccountController : Controller
    {
		private readonly WebForSellContext _context;

		public AccountController(WebForSellContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
			return View();
		}
		public IActionResult Login()
		{
			return View();
        }
		[HttpPost]
		public IActionResult Login(User _userFormPage)
		{
			var _user = _context.User.Where(m => m.UserEmail == _userFormPage.UserEmail && m.UserPassword == _userFormPage.UserPassword).FirstOrDefault();
			if (_user == null)
			{
				ViewBag.LoginStatus = 0;
			}
			else
			{
				var claims = new List<Claim>
				 {
						new Claim(ClaimTypes.Name, _user.UserEmail),
						new Claim("FullName", _user.UserName),
						new Claim(ClaimTypes.Role, _user.UserRole),
				 };

				var claimsIdentity = new ClaimsIdentity(
					claims, CookieAuthenticationDefaults.AuthenticationScheme);

				var authProperties = new AuthenticationProperties
				{

				};

				HttpContext.SignInAsync(
				   CookieAuthenticationDefaults.AuthenticationScheme,
				   new ClaimsPrincipal(claimsIdentity),
				   authProperties);
				return RedirectToAction("Index", "Account");
			}
			return View();
		}
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(
			CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Account");
		}
	}
}
