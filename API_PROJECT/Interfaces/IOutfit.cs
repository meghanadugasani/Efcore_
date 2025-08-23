using WardrobeAPI.Models;

namespace WardrobeAPI.Interfaces
{
    public interface IOutfit
    {
        Task<Outfit> GetOutfitByIdAsync(int id);
        Task<IEnumerable<Outfit>> GetAllOutfitsAsync();
        Task<Outfit> CreateOutfitAsync(Outfit outfit);
        Task<Outfit> UpdateOutfitAsync(Outfit outfit);
        Task<bool> DeleteOutfitAsync(int id);

        Task<IEnumerable<Outfit>> SearchAsync(string keyword);
        Task<IEnumerable<Outfit>> FilterAsync(string? name, string? season, string? style, int? wardrobeId);
    }
}
