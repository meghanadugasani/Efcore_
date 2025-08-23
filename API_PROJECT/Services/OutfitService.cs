using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Services
{
    public class OutfitService
    {
        private readonly IOutfit _outfitRepo;

        public OutfitService(IOutfit outfitRepo)
        {
            _outfitRepo = outfitRepo;
        }

        public Task<Outfit> GetOutfitByIdAsync(int id) => _outfitRepo.GetOutfitByIdAsync(id);
        public Task<IEnumerable<Outfit>> GetAllOutfitsAsync() => _outfitRepo.GetAllOutfitsAsync();
        public Task<Outfit> CreateOutfitAsync(Outfit outfit) => _outfitRepo.CreateOutfitAsync(outfit);
        public Task<Outfit> UpdateOutfitAsync(Outfit outfit) => _outfitRepo.UpdateOutfitAsync(outfit);
        public Task<bool> DeleteOutfitAsync(int id) => _outfitRepo.DeleteOutfitAsync(id);

        public Task<IEnumerable<Outfit>> SearchAsync(string keyword) => _outfitRepo.SearchAsync(keyword);
        public Task<IEnumerable<Outfit>> FilterAsync(string? name, string? season, string? style, int? wardrobeId)
            => _outfitRepo.FilterAsync(name, season, style, wardrobeId);
    }
}
