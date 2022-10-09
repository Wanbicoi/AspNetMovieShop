using Microsoft.AspNetCore.Mvc;
using MovieShop.Data.Cart;

namespace MovieShop.Data.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    {
        readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            int res = _shoppingCart.GetShoppingCartItems().Count;
            return View(res);
        }
    }
}
