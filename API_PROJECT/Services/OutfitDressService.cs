using WardrobeAPI.Interfaces;
using WardrobeAPI.Models;

namespace WardrobeAPI.Services
{
    public class OutfitDressService
    {
        private readonly IOutfitDress _outfitDressRepo;

        public OutfitDressService(IOutfitDress outfitDressRepo)
        {
            _outfitDressRepo = outfitDressRepo;
        }

        public Task<OutfitDress> AddDressToOutfitAsync(int outfitId, int dressId) =>
            _outfitDressRepo.AddDressToOutfitAsync(outfitId, dressId);

        public Task<bool> RemoveDressFromOutfitAsync(int outfitId, int dressId) =>
            _outfitDressRepo.RemoveDressFromOutfitAsync(outfitId, dressId);

        public Task<OutfitDress> GetByOutfitAndDressAsync(int outfitId, int dressId) =>
            _outfitDressRepo.GetByOutfitAndDressAsync(outfitId, dressId);

        public Task<IEnumerable<Dress>> GetDressesByOutfitAsync(int outfitId) =>
            _outfitDressRepo.GetDressesByOutfitAsync(outfitId);

        public Task<IEnumerable<Outfit>> GetOutfitsByDressAsync(int dressId) =>
            _outfitDressRepo.GetOutfitsByDressAsync(dressId);

        public Task<IEnumerable<Dress>> SearchDressesInOutfitAsync(int outfitId, string keyword) =>
           _outfitDressRepo.SearchDressesInOutfitAsync(outfitId, keyword);

        public Task<IEnumerable<Outfit>> FilterOutfitsByDressAsync(int dressId, string? season, string? style) =>
            _outfitDressRepo.FilterOutfitsByDressAsync(dressId, season, style);
    }
}
