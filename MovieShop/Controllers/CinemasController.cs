using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Data.Services;
using MovieShop.Models;

namespace MovieShop.Controllers
{
    [Authorize(Roles = Data.Static.UserRoles.Admin)]
    public class CinemasController : Controller
    {
        ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,ImageUrl,Description")]Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cinema cinema)
        {
            try
            {
                await _service.UpdateAsync(cinema);
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
