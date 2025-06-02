using DistrictWebapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistrictWebapp.Controllers
{
    public class CityMvcController : Controller
    {
        private readonly ICityService _cityService;

        public CityMvcController(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<IActionResult> Index(string search)
        {
            ViewData["Search"] = search;

            var cities = await _cityService.GetAllCitiesAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                cities = cities
                    .Where(c => c.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(cities);
        }

        public async Task<IActionResult> Details(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();

            return View(city);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}


    }
}
