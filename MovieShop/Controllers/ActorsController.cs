using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Data.Services;
using MovieShop.Models;

namespace MovieShop.Controllers
{
    [Authorize(Roles = Data.Static.UserRoles.Admin)]
    public class ActorsController : Controller
    {
        IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,ImageUrl,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Actor actor)
        {
            try
            {
                await _service.UpdateAsync(actor);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel() { RequestId = e.Message});
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel() { RequestId = e.Message});
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
