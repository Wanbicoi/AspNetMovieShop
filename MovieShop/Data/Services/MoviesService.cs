using Microsoft.EntityFrameworkCore;
using MovieShop.Data.Base;
using MovieShop.Data.ViewModels;
using MovieShop.Models;

namespace MovieShop.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        ApplicationDbContext _context;
        public MoviesService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateMovieAsync(CreateMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageURL,
                CinemaID = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Category = data.MovieCategory,
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new MovieActor()
                {
                    MovieID = newMovie.ID,
                    ActorID = actorId
                };
                await _context.MovieActors.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<CreateMovieDropdownsVM> GetCreateMovieDropdownsValues()
        {
            var response = new CreateMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.Name).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
            };
            return response;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(am => am.MovieActors).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.ID == id);
            if (movieDetails == null) throw new Exception("Can not find item!");
            return movieDetails;
        }

        public async Task UpdateMovieAsync(CreateMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.ID == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageUrl = data.ImageURL;
                dbMovie.CinemaID = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.Category = data.MovieCategory;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.MovieActors.Where(n => n.MovieID == data.Id).ToList();
            _context.MovieActors.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new MovieActor()
                {
                    MovieID = data.Id,
                    ActorID = actorId
                };
                await _context.MovieActors.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
