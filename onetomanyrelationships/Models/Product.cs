using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codefirstmvc.Models
{
    public class Product
    {
        [Key]
        public int Proid { get; set; }

        public string Prodname { get; set; }
        public decimal price { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
