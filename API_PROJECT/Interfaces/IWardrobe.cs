using WardrobeAPI.Models;

namespace WardrobeAPI.Interfaces
{
    public interface IWardrobe
    {
        Task<Wardrobe> GetWardrobeByIdAsync(int id);
        Task<IEnumerable<Wardrobe>> GetAllWardrobesAsync();
        Task<Wardrobe> CreateWardrobeAsync(Wardrobe wardrobe);
        Task<Wardrobe> UpdateWardrobeAsync(Wardrobe wardrobe);
        Task<bool> DeleteWardrobeAsync(int id);

        Task<IEnumerable<Wardrobe>> SearchAsync(string keyword);
        Task<IEnumerable<Wardrobe>> FilterAsync(string? name, int? userId);

    }
}
