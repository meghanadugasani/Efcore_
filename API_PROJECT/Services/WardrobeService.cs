using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Services
{
    public class WardrobeService
    {
        private readonly IWardrobe _wardrobeRepo;

        public WardrobeService(IWardrobe wardrobeRepo)
        {
            _wardrobeRepo = wardrobeRepo;
        }

        public Task<Wardrobe> GetWardrobeByIdAsync(int id) => _wardrobeRepo.GetWardrobeByIdAsync(id);
        public Task<IEnumerable<Wardrobe>> GetAllWardrobesAsync() => _wardrobeRepo.GetAllWardrobesAsync();
        public Task<Wardrobe> CreateWardrobeAsync(Wardrobe wardrobe) => _wardrobeRepo.CreateWardrobeAsync(wardrobe);
        public Task<Wardrobe> UpdateWardrobeAsync(Wardrobe wardrobe) => _wardrobeRepo.UpdateWardrobeAsync(wardrobe);
        public Task<bool> DeleteWardrobeAsync(int id) => _wardrobeRepo.DeleteWardrobeAsync(id);
        public Task<IEnumerable<Wardrobe>> SearchAsync(string keyword) => _wardrobeRepo.SearchAsync(keyword);
        public Task<IEnumerable<Wardrobe>> FilterAsync(string? name, int? userId) => _wardrobeRepo.FilterAsync(name, userId);
    }
}
