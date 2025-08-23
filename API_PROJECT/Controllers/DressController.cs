using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeAPI.Models;
using WardrobeAPI.Services;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class DressController : ControllerBase
{
    private readonly DressService _dressService;

    public DressController(DressService dressService)
    {
        _dressService = dressService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _dressService.GetAllDressesAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dress = await _dressService.GetDressByIdAsync(id);
        if (dress == null) return NotFound();
        return Ok(dress);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Dress dress)
    {
        var created = await _dressService.CreateDressAsync(dress);
        return CreatedAtAction(nameof(GetById), new { id = created.DressId }, created);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, Dress dress)
    {
        if (id != dress.DressId) return BadRequest();
        var updated = await _dressService.UpdateDressAsync(dress);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _dressService.DeleteDressAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string keyword)
    {
        var results = await _dressService.SearchAsync(keyword);
        return Ok(results);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] string? color, [FromQuery] string? size,
                                            [FromQuery] string? season, [FromQuery] string? style)
    {
        var results = await _dressService.FilterAsync(color, size, season, style);
        return Ok(results);
    }
}
