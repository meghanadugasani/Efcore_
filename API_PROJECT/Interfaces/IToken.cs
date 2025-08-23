
using WardrobeAPI.Models;

namespace WardrobeAPI.Interfaces
{
    public interface IToken
    {
        public string GenerateToken(User user);
    }
}
