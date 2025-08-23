using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Services
{
    public class UserService
    {
        private readonly IUser _userRepo;

        public UserService(IUser userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<User> GetUserByIdAsync(int id) => _userRepo.GetUserByIdAsync(id);
        public Task<IEnumerable<User>> GetAllUsersAsync() => _userRepo.GetAllUsersAsync();
        public Task<User> CreateUserAsync(User user) => _userRepo.CreateUserAsync(user);
        public Task<User> UpdateUserAsync(User user) => _userRepo.UpdateUserAsync(user);
        public Task<bool> DeleteUserAsync(int id) => _userRepo.DeleteUserAsync(id);
    }
}
