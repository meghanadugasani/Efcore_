using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Services
{
    public class DressService
    {
        private readonly IDress _dressRepo;

        public DressService(IDress dressRepo)
        {
            _dressRepo = dressRepo;
        }

        public Task<Dress> GetDressByIdAsync(int id) => _dressRepo.GetDressByIdAsync(id);
        public Task<IEnumerable<Dress>> GetAllDressesAsync() => _dressRepo.GetAllDressesAsync();
        public Task<Dress> CreateDressAsync(Dress dress) => _dressRepo.CreateDressAsync(dress);
        public Task<Dress> UpdateDressAsync(Dress dress) => _dressRepo.UpdateDressAsync(dress);
        public Task<bool> DeleteDressAsync(int id) => _dressRepo.DeleteDressAsync(id);
        public Task<IEnumerable<Dress>> SearchAsync(string keyword) => _dressRepo.SearchAsync(keyword);
        public Task<IEnumerable<Dress>> FilterAsync(string? color, string? size, string? season, string? style)
            => _dressRepo.FilterAsync(color, size, season, style);
    }
}
