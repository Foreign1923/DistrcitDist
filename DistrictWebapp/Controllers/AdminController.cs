using DistrictWebapp.Models;
using DistrictWebapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistrictWebapp.Controllers
{
    public class AdminController: Controller
    {
        private readonly ICityService _cityService;

        public AdminController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return View(cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            if (!ModelState.IsValid)
                return View(city);

            await _cityService.AddCityAsync(city);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _cityService.DeleteCityAsync(id);
            return RedirectToAction("Index");
        }

    }
}
