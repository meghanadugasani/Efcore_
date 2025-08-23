using WardrobeAPI.Models;

namespace WardrobeAPI.Interfaces
{
    public interface IOutfitDress
    {
        Task<OutfitDress> GetByOutfitAndDressAsync(int outfitId, int dressId);
        Task<OutfitDress> AddDressToOutfitAsync(int outfitId, int dressId);
        Task<bool> RemoveDressFromOutfitAsync(int outfitId, int dressId);
        Task<IEnumerable<Dress>> GetDressesByOutfitAsync(int outfitId);
        Task<IEnumerable<Outfit>> GetOutfitsByDressAsync(int dressId);

        Task<IEnumerable<Dress>> SearchDressesInOutfitAsync(int outfitId, string keyword);
        Task<IEnumerable<Outfit>> FilterOutfitsByDressAsync(int dressId, string? season, string? style);
    }
}
