using Microsoft.AspNetCore.Mvc;
using mission9_ear69.Models;
namespace mission9_ear69.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket basketS)
        {
            basket = basketS;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
