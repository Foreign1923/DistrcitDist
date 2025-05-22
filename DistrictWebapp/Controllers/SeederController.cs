using DistrictWebapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistrictWebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeederController : ControllerBase
    {
        private readonly SeederService _seederService;

        public SeederController(SeederService seederService)
        {
            _seederService = seederService;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> Seed()
        {
            await _seederService.SeedFromJsonAsync();
            return Ok("Veri başarıyla veritabanına eklendi.");
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("SeederController aktif.");
        }

    }
}
