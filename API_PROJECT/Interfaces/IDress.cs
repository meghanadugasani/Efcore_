using WardrobeAPI.Models;

namespace WardrobeAPI.Interfaces
{
    public interface IDress
    {
        Task<Dress> GetDressByIdAsync(int id);
        Task<IEnumerable<Dress>> GetAllDressesAsync();
        Task<Dress> CreateDressAsync(Dress dress);
        Task<Dress> UpdateDressAsync(Dress dress);
        Task<bool> DeleteDressAsync(int id);
        Task<IEnumerable<Dress>> SearchAsync(string keyword);
        Task<IEnumerable<Dress>> FilterAsync(string? color, string? size, string? season, string? style);
    }

}
