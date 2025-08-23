using Microsoft.EntityFrameworkCore;
using WardrobeAPI.Data;
using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Repositories
{
    public class OutfitRepository : IOutfit
    {
        private readonly WardrobeContext _context;

        public OutfitRepository(WardrobeContext context)
        {
            _context = context;
        }

        public async Task<Outfit> CreateOutfitAsync(Outfit outfit)
        {
            _context.Outfits.Add(outfit);
            await _context.SaveChangesAsync();
            return outfit;
        }

        public async Task<bool> DeleteOutfitAsync(int id)
        {
            var outfit = await _context.Outfits.FindAsync(id);
            if (outfit == null) return false;

            _context.Outfits.Remove(outfit);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Outfit>> GetAllOutfitsAsync()
        {
            return await _context.Outfits
                .Include(o => o.OutfitDresses)
                    .ThenInclude(od => od.Dress)
                .ToListAsync();
        }

        public async Task<Outfit> GetOutfitByIdAsync(int id)
        {
            return await _context.Outfits
                .Include(o => o.OutfitDresses)
                    .ThenInclude(od => od.Dress)
                .FirstOrDefaultAsync(o => o.OutfitId == id);
        }

        public async Task<Outfit> UpdateOutfitAsync(Outfit outfit)
        {
            _context.Outfits.Update(outfit);
            await _context.SaveChangesAsync();
            return outfit;
        }

        public async Task<IEnumerable<Outfit>> SearchAsync(string keyword)
        {
            return await _context.Outfits
                .Include(o => o.OutfitDresses)
                    .ThenInclude(od => od.Dress)
                .Where(o => o.Name.Contains(keyword) ||
                            o.OutfitDresses.Any(od => od.Dress.Name.Contains(keyword)))
                .ToListAsync();
        }

       
        public async Task<IEnumerable<Outfit>> FilterAsync(string? name, string? season, string? style, int? wardrobeId)
        {
            var query = _context.Outfits
                .Include(o => o.OutfitDresses)
                    .ThenInclude(od => od.Dress)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(o => o.Name.Contains(name));

            if (!string.IsNullOrEmpty(season))
                query = query.Where(o => o.Season == season);

            if (!string.IsNullOrEmpty(style))
                query = query.Where(o => o.Style == style);

            if (wardrobeId.HasValue)
                query = query.Where(o => o.WardrobeId == wardrobeId.Value);

            return await query.ToListAsync();
        }
    }
}
