using Microsoft.EntityFrameworkCore;
using WardrobeAPI.Data;
using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Repositories
{
    public class DressRepository : IDress
    {
        private readonly WardrobeContext _context;

        public DressRepository(WardrobeContext context)
        {
            _context = context;
        }

        public async Task<Dress> CreateDressAsync(Dress dress)
        {
            _context.Dresses.Add(dress);
            await _context.SaveChangesAsync();
            return dress;
        }

        public async Task<bool> DeleteDressAsync(int id)
        {
            var dress = await _context.Dresses.FindAsync(id);
            if (dress == null) return false;

            _context.Dresses.Remove(dress);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Dress>> GetAllDressesAsync()
        {
            return await _context.Dresses
                .Include(d => d.Wardrobe)
                .Include(d => d.OutfitDresses)
                    .ThenInclude(od => od.Outfit)
                .ToListAsync();
        }

        public async Task<Dress> GetDressByIdAsync(int id)
        {
            return await _context.Dresses
                .Include(d => d.Wardrobe)
                .Include(d => d.OutfitDresses)
                    .ThenInclude(od => od.Outfit)
                .FirstOrDefaultAsync(d => d.DressId == id);
        }

        public async Task<Dress> UpdateDressAsync(Dress dress)
        {
            _context.Dresses.Update(dress);
            await _context.SaveChangesAsync();
            return dress;
        }
        public async Task<IEnumerable<Dress>> SearchAsync(string keyword)
        {
            return await _context.Dresses
                .Include(d => d.Wardrobe)
                .Include(d => d.OutfitDresses).ThenInclude(od => od.Outfit)
                .Where(d => d.Name.Contains(keyword) || d.Color.Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<Dress>> FilterAsync(string? color, string? size, string? season, string? style)
        {
            var query = _context.Dresses
                .Include(d => d.Wardrobe)
                .Include(d => d.OutfitDresses).ThenInclude(od => od.Outfit)
                .AsQueryable();

            if (!string.IsNullOrEmpty(color))
                query = query.Where(d => d.Color == color);

            if (!string.IsNullOrEmpty(size))
                query = query.Where(d => d.Size == size);

            if (!string.IsNullOrEmpty(season))
                query = query.Where(d => d.Season == season);

            if (!string.IsNullOrEmpty(style))
                query = query.Where(d => d.Style == style);

            return await query.ToListAsync();
        }
    }
}
