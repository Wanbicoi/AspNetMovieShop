using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; } = default!;

        public string UserId { get; set; } = default!;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = default!;

        public List<OrderItem> OrderItems { get; set; } = default!;
    }
}
