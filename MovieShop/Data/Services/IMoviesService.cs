using MovieShop.Data.Base;
using MovieShop.Data.ViewModels;
using MovieShop.Models;

namespace MovieShop.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task CreateMovieAsync(CreateMovieVM data);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<CreateMovieDropdownsVM> GetCreateMovieDropdownsValues();
        Task UpdateMovieAsync(CreateMovieVM data);
    }
}
