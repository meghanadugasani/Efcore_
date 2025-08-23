namespace WardrobeAPI.Models
{
    public class OutfitDress
    {
        public int OutfitId { get; set; }
        public Outfit? Outfit { get; set; }

        public int DressId { get; set; }
        public Dress? Dress { get; set; }
    }

}
