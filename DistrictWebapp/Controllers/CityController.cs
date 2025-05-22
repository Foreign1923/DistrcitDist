using Microsoft.AspNetCore.Mvc;
using DistrictWebapp.Models;
using DistrictWebapp.Services;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cities = await _cityService.GetAllCitiesAsync();
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var city = await _cityService.GetCityByIdAsync(id);
        if (city == null)
            return NotFound();
        return Ok(city);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string name)
    {
        var results = await _cityService.SearchCitiesByNameAsync(name);
        return Ok(results);
    }

    [HttpPost]
    public async Task<IActionResult> Create(City city)
    {
        await _cityService.AddCityAsync(city);
        return CreatedAtAction(nameof(GetById), new { id = city.Id }, city);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, City city)
    {
        if (id != city.Id) return BadRequest();
        await _cityService.UpdateCityAsync(city);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _cityService.DeleteCityAsync(id);
        return NoContent();
    }
    
}
