using Microsoft.AspNetCore.Mvc;
using DistrictWebapp.Models;
using DistrictWebapp.Services;

[ApiController]
[Route("api/[controller]")]
public class DistrictController : ControllerBase
{
    private readonly IDistrictService _districtService;

    public DistrictController(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var districts = await _districtService.GetAllDistrictsAsync();
        return Ok(districts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var district = await _districtService.GetDistrictByIdAsync(id);
        if (district == null)
            return NotFound();
        return Ok(district);
    }

    [HttpGet("byCity/{cityId}")]
    public async Task<IActionResult> GetByCityId(int cityId)
    {
        var districts = await _districtService.GetDistrictsByCityIdAsync(cityId);
        return Ok(districts);
    }

    [HttpPost]
    public async Task<IActionResult> Create(District district)
    {
        await _districtService.AddDistrictAsync(district);
        return CreatedAtAction(nameof(GetById), new { id = district.Id }, district);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, District district)
    {
        if (id != district.Id) return BadRequest();
        await _districtService.UpdateDistrictAsync(district);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _districtService.DeleteDistrictAsync(id);
        return NoContent();
    }
}
