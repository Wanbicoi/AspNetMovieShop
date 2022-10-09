using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieShop.Data.Services;
using MovieShop.Data.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;

namespace MovieShop.Controllers
{
    [Authorize(Roles = Data.Static.UserRoles.Admin)]
    public class MoviesController : Controller
    {
        IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _service.GetMovieByIdAsync(id));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync(n => n.Cinema));
        }

        public async Task<IActionResult> Create()
        {
            var list = await _service.GetCreateMovieDropdownsValues();
            ViewBag.Actors = new SelectList(list.Actors, "ID", "Name");
            ViewBag.Cinemas = new SelectList(list.Cinemas, "ID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieVM createMovieVM)
        {
            await _service.CreateMovieAsync(createMovieVM);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new CreateMovieVM()
            {
                Id = movieDetails.ID,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageUrl,
                MovieCategory = movieDetails.Category ?? Data.Enums.Category.Drama,
                CinemaId = movieDetails.CinemaID ?? 1,

                ActorIds = movieDetails.MovieActors.Select(n => n.ActorID).ToList(),
            };

            var movieDropdownsData = await _service.GetCreateMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "ID", "Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ID", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateMovieVM createMovieVM)
        {
            await _service.UpdateMovieAsync(createMovieVM);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            if (String.IsNullOrWhiteSpace(searchString)) RedirectToAction("Index");

            IEnumerable<Models.Movie> res = await _service.GetAllAsync(p => p.Cinema);
            res = res.Where(p => p.Name.Contains(searchString));

            return View("Index", res);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
