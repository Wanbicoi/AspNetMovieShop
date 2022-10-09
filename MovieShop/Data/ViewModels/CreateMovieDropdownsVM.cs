using MovieShop.Models;

namespace MovieShop.Data.ViewModels
{
    public class CreateMovieDropdownsVM
    {
        public CreateMovieDropdownsVM()
        {
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
