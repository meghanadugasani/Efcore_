using System.ComponentModel.DataAnnotations;

namespace codefirstmvc.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        // One category has many products
        public IList<Product> Products { get; set; }
    }
}
