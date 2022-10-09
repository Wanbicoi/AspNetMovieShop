using MovieShop.Data.Cart;

namespace MovieShop.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; } = default!;
        public double ShoppingCartTotal { get; set; }
    }
}
