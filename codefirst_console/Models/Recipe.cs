using System.ComponentModel.DataAnnotations;

namespace codefirst1.Models
{
    public class Recipe
    {
        [Key]
        public int ProductId { get; set; }  // Primary key, auto-generated

        [Required]
        [StringLength(100)]
        public string RecipeName { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Instructions { get; set; }
    }
}
