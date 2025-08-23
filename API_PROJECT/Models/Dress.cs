using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WardrobeAPI.Models
{
    public class Dress
    {
        public int DressId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Season { get; set; }
        public string? Style { get; set; }

        // Foreign key to Wardrobe (nullable if optional)
        public int? WardrobeId { get; set; } 
        // Navigation property to Wardrobe
        public Wardrobe? Wardrobe { get; set; }

        // Navigation property for many-to-many with Outfit
        public ICollection<OutfitDress>? OutfitDresses { get; set; }
    }
}
