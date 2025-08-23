using Microsoft.EntityFrameworkCore;
using WardrobeAPI.Data;
using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Repositories
{
    public class OutfitDressRepository : IOutfitDress
    {
        private readonly WardrobeContext _context;

        public OutfitDressRepository(WardrobeContext context)
        {
            _context = context;
        }

        public async Task<OutfitDress> AddDressToOutfitAsync(int outfitId, int dressId)
        {
            var outfitDress = new OutfitDress { OutfitId = outfitId, DressId = dressId };
            _context.OutfitDresses.Add(outfitDress);
            await _context.SaveChangesAsync();
            return outfitDress;
        }

        public async Task<bool> RemoveDressFromOutfitAsync(int outfitId, int dressId)
        {
            var outfitDress = await _context.OutfitDresses
                .FirstOrDefaultAsync(od => od.OutfitId == outfitId && od.DressId == dressId);
            if (outfitDress == null) return false;

            _context.OutfitDresses.Remove(outfitDress);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<OutfitDress> GetByOutfitAndDressAsync(int outfitId, int dressId)
        {
            return await _context.OutfitDresses
                .FirstOrDefaultAsync(od => od.OutfitId == outfitId && od.DressId == dressId);
        }

        public async Task<IEnumerable<Dress>> GetDressesByOutfitAsync(int outfitId)
        {
            return await _context.OutfitDresses
                .Where(od => od.OutfitId == outfitId)
                .Select(od => od.Dress)
                .ToListAsync();
        }

        public async Task<IEnumerable<Outfit>> GetOutfitsByDressAsync(int dressId)
        {
            return await _context.OutfitDresses
                .Where(od => od.DressId == dressId)
                .Select(od => od.Outfit)
                .ToListAsync();
        }
        public async Task<IEnumerable<Dress>> SearchDressesInOutfitAsync(int outfitId, string keyword)
        {
            return await _context.OutfitDresses
                .Where(od => od.OutfitId == outfitId && od.Dress.Name.Contains(keyword))
                .Select(od => od.Dress)
                .ToListAsync();
        }


        public async Task<IEnumerable<Outfit>> FilterOutfitsByDressAsync(int dressId, string? season, string? style)
        {
            var query = _context.OutfitDresses
                .Where(od => od.DressId == dressId)
                .Select(od => od.Outfit)
                .AsQueryable();

            if (!string.IsNullOrEmpty(season))
                query = query.Where(o => o.Season == season);

            if (!string.IsNullOrEmpty(style))
                query = query.Where(o => o.Style == style);

            return await query.ToListAsync();
        }
    }
}
