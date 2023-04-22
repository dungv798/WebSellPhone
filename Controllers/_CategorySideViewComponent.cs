using Microsoft.AspNetCore.Mvc;
using WebForSell.Data;

namespace WebForSell.Controllers
{
    [ViewComponent(Name ="_CategorySide")]
    public class _CategorySideViewComponent: ViewComponent
    {
        private readonly WebForSellContext _context;

        public _CategorySideViewComponent(WebForSellContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var _category = _context.Category.ToList();
            return View("_CategorySide", _category);
        }
    }
}
