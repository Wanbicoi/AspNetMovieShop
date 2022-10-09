using MovieShop.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
