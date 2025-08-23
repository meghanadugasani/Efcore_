using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeAPI.Models;
using WardrobeAPI.Services;

namespace WardrobeAPI.Controllers
{
    [ApiController]
    [Authorize] 
    [Route("api/[controller]")]
    public class WardrobeController : ControllerBase
    {
        private readonly WardrobeService _wardrobeService;

        public WardrobeController(WardrobeService wardrobeService)
        {
            _wardrobeService = wardrobeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _wardrobeService.GetAllWardrobesAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var wardrobe = await _wardrobeService.GetWardrobeByIdAsync(id);
            if (wardrobe == null) return NotFound();
            return Ok(wardrobe);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Wardrobe wardrobe)
        {
            var created = await _wardrobeService.CreateWardrobeAsync(wardrobe);
            return CreatedAtAction(nameof(GetById), new { id = created.WardrobeId }, created);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, Wardrobe wardrobe)
        {
            if (id != wardrobe.WardrobeId) return BadRequest();
            var updated = await _wardrobeService.UpdateWardrobeAsync(wardrobe);
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _wardrobeService.DeleteWardrobeAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var results = await _wardrobeService.SearchAsync(keyword);
            return Ok(results);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] string? name, [FromQuery] int? userId)
        {
            var results = await _wardrobeService.FilterAsync(name, userId);
            return Ok(results);
        }
    }
}
