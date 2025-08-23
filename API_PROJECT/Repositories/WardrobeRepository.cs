using Microsoft.EntityFrameworkCore;
using WardrobeAPI.Data;
using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Repositories
{
    public class WardrobeRepository : IWardrobe
    {
        private readonly WardrobeContext _context;

        public WardrobeRepository(WardrobeContext context)
        {
            _context = context;
        }

        public async Task<Wardrobe> CreateWardrobeAsync(Wardrobe wardrobe)
        {
            _context.Wardrobes.Add(wardrobe);
            await _context.SaveChangesAsync();
            return wardrobe;
        }

        public async Task<bool> DeleteWardrobeAsync(int id)
        {
            var wardrobe = await _context.Wardrobes.FindAsync(id);
            if (wardrobe == null) return false;

            _context.Wardrobes.Remove(wardrobe);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Wardrobe>> GetAllWardrobesAsync()
        {
            return await _context.Wardrobes
                .Include(w => w.Dresses)
                .ToListAsync();
        }

        public async Task<Wardrobe> GetWardrobeByIdAsync(int id)
        {
            return await _context.Wardrobes
                .Include(w => w.Dresses)
                .FirstOrDefaultAsync(w => w.WardrobeId == id);
        }

        public async Task<Wardrobe> UpdateWardrobeAsync(Wardrobe wardrobe)
        {
            _context.Wardrobes.Update(wardrobe);
            await _context.SaveChangesAsync();
            return wardrobe;
        }

        public async Task<IEnumerable<Wardrobe>> SearchAsync(string keyword)
        {
            return await _context.Wardrobes
                .Include(w => w.Dresses)
                .Where(w => w.Name.Contains(keyword))
                .ToListAsync();
        }
        public async Task<IEnumerable<Wardrobe>> FilterAsync(string? name, int? userId)
        {
            var query = _context.Wardrobes
                .Include(w => w.Dresses)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(w => w.Name.Contains(name));

            if (userId.HasValue)
                query = query.Where(w => w.UserId == userId.Value);

            return await query.ToListAsync();
        }
    }
}
