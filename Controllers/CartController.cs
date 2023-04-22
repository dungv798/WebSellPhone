using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebForSell.Data;
using WebForSell.Infrastructure;
using WebForSell.Models;
using WebForSell.Models.ViewModels;

namespace WebForSell.Controllers
{
    [Authorize(Roles = "customer")]
    public class CartController : Controller
    {
        private readonly WebForSellContext _context;

        public CartController(WebForSellContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart")?? new List<CartItem>();
            
            SmallCartViewModel cartVM1 = new()
            {
                NumberOfItems = cart.Sum(x => x.Quantity),
                TotalAmount = (int)cart.Sum(x => x.Quantity * x.Price)

            };
            return View(cartVM1);
        }
        public IActionResult Index2()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandToTal = (int)cart.Sum(x => x.Quantity * x.Price)

            };
            
            return View(cartVM);
        }
        public IActionResult CheckOut()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandToTal = (int)cart.Sum(x => x.Quantity * x.Price)

            };

            return View(cartVM);
        }
        public async Task<IActionResult> Add(int id)
        {
            Product product = await _context.Product.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            
            CartItem cartItem =  cart.Where(c => c.ProductId == id).FirstOrDefault();
            
            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has benn added";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Decrease(int id)
        {

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity>1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == id);
            }

            if(cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            } 
                

            TempData["Success"] = "The product has benn Removed";
            return RedirectToAction("Index2");
        }
        public async Task<IActionResult> Remove(int id)
        {

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            cart.RemoveAll(p => p.ProductId == id);


            
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }


            TempData["Success"] = "The product has benn Removed";
            return RedirectToAction("Index2");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart"); 
            return RedirectToAction("Index2");
        }
    }
}
