using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DistrictWebapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var svgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "tr.svg");
            var svgContent = System.IO.File.ReadAllText(svgPath);
            ViewBag.TurkeyMap = svgContent;

            return View();
        }
    }
}
