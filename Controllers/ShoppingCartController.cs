using Microsoft.AspNetCore.Mvc;
using mission9_ear69.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_ear69.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IShoppingCartRepository repo { get; set; }
        private Basket basket { get; set; }
        public ShoppingCartController(IShoppingCartRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new ShoppingCart());
        }

        [HttpPost]
        public IActionResult Checkout(ShoppingCart shoppingCart)
        {
            if (basket.Items.Count()==0)
            {
                ModelState.AddModelError("", "Sorry bruv your ting is empty");
            }
            if (ModelState.IsValid)
            {
                shoppingCart.Lines = basket.Items.ToArray();
                repo.SaveShoppingCart(shoppingCart);
                basket.ClearBasekt();

                return RedirectToPage("/Completed");
            }
            else
            {
                return View();
            }
        }
    }
}
