using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeAPI.Models;
using WardrobeAPI.Services;

namespace WardrobeAPI.Controllers
{
    [ApiController]
    [Authorize] 
    [Route("api/[controller]")]
    public class OutfitController : ControllerBase
    {
        private readonly OutfitService _outfitService;

        public OutfitController(OutfitService outfitService)
        {
            _outfitService = outfitService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _outfitService.GetAllOutfitsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var outfit = await _outfitService.GetOutfitByIdAsync(id);
            if (outfit == null) return NotFound();
            return Ok(outfit);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Outfit outfit)
        {
            var created = await _outfitService.CreateOutfitAsync(outfit);
            return CreatedAtAction(nameof(GetById), new { id = created.OutfitId }, created);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, Outfit outfit)
        {
            if (id != outfit.OutfitId) return BadRequest();
            var updated = await _outfitService.UpdateOutfitAsync(outfit);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _outfitService.DeleteOutfitAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var results = await _outfitService.SearchAsync(keyword);
            return Ok(results);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] string? name, [FromQuery] string? season,
                                                [FromQuery] string? style, [FromQuery] int? wardrobeId)
        {
            var results = await _outfitService.FilterAsync(name, season, style, wardrobeId);
            return Ok(results);
        }
    }
}
