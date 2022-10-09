using MovieShop.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? Decriptions { get; set; }
        public ICollection<MovieActor>? MovieActors { get; set; }
    }
}
