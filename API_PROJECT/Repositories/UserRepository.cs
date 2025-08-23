using Microsoft.EntityFrameworkCore;
using WardrobeAPI.Data;
using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Repositories
{
    public class UserRepository : IUser
    {
        private readonly WardrobeContext _context;

        public UserRepository(WardrobeContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Wardrobes)
                .ThenInclude(w => w.Dresses)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
