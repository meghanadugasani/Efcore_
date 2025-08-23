namespace WardrobeAPI.Models
{
    public class Wardrobe
    {
        public int? WardrobeId { get; set; }
        public string? Name { get; set; }

        // Foreign key to User
        public int UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Dress>? Dresses { get; set; }
    }

}
