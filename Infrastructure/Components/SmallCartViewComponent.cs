﻿using Microsoft.AspNetCore.Mvc;
using WebForSell.Models;
using WebForSell.Models.ViewModels;

namespace WebForSell.Infrastructure.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCartViewModel smallCartVM;
            if(cart == null || cart.Count == 0)
            {
                smallCartVM = null;
            }else
            {
                smallCartVM = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = (int)cart.Sum(x => x.Quantity * x.Price)

                };
            }
            return View(smallCartVM);
        }
    }
}
