namespace WardrobeAPI.Models
{
    public class Outfit
    {
        public int OutfitId { get; set; }
        public string? Name { get; set; } 
        public string? Occasion { get; set; }
        public string? Season { get; set; }
        public string? Style { get; set; }

        // Navigation property for many-to-many with Dress
        public ICollection<OutfitDress>? OutfitDresses { get; set; }
        public int WardrobeId { get; internal set; }
    }

}
