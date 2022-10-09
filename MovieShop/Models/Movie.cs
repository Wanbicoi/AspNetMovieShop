using MovieShop.Data.Base;
using MovieShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; internal set; } = default!;
        public string? Description { get; internal set; }
        public double Price { get; internal set; }

        public string? ImageUrl { get; set; }

        public Category? Category { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? CinemaID { get; set; }

        [ForeignKey("CinemaID")]
        public Cinema Cinema { get; set; } = default!;

        public ICollection<MovieActor> MovieActors { get; set; } = default!;
    }
}
