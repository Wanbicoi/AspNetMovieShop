using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Movie Movie { get; set; } = default!; 
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; } = default!; 
    }
}
