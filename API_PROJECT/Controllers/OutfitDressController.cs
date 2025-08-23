using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeAPI.Services;

namespace WardrobeAPI.Controllers
{
    [ApiController]
    [Authorize] 
    [Route("api/[controller]")]
    public class OutfitDressController : ControllerBase
    {
        private readonly OutfitDressService _outfitDressService;

        public OutfitDressController(OutfitDressService outfitDressService)
        {
            _outfitDressService = outfitDressService;
        }
        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDressToOutfit(int outfitId, int dressId)
        {
            var result = await _outfitDressService.AddDressToOutfitAsync(outfitId, dressId);
            return CreatedAtAction(nameof(GetByOutfitAndDress), new { outfitId, dressId }, result);
        }
        [HttpDelete("Remove")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveDressFromOutfit(int outfitId, int dressId)
        {
            var deleted = await _outfitDressService.RemoveDressFromOutfitAsync(outfitId, dressId);
            if (!deleted) return NotFound();
            return NoContent();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetByOutfitAndDress(int outfitId, int dressId)
        {
            var result = await _outfitDressService.GetByOutfitAndDressAsync(outfitId, dressId);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet("Dresses/{outfitId}")]
        public async Task<IActionResult> GetDressesByOutfit(int outfitId)
        {
            var dresses = await _outfitDressService.GetDressesByOutfitAsync(outfitId);
            return Ok(dresses);
        }
        [HttpGet("Outfits/{dressId}")]
        public async Task<IActionResult> GetOutfitsByDress(int dressId)
        {
            var outfits = await _outfitDressService.GetOutfitsByDressAsync(dressId);
            return Ok(outfits);
        }
        [HttpGet("SearchDresses")]
        public async Task<IActionResult> SearchDressesInOutfit(int outfitId, string keyword)
        {
            var results = await _outfitDressService.SearchDressesInOutfitAsync(outfitId, keyword);
            return Ok(results);
        }
        [HttpGet("FilterOutfits")]
        public async Task<IActionResult> FilterOutfitsByDress(int dressId, string? season, string? style)
        {
            var results = await _outfitDressService.FilterOutfitsByDressAsync(dressId, season, style);
            return Ok(results);
        }
    }
}
