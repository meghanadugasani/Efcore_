using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace codefirstmvc.Models
{
    public class ProductContext : DbContext //inheriting dbcontext class from entity framework core //performs all operations with ur db
    {
        public DbSet<Product> Products { get; set; }  //list of productsf for product entity refered as dbset
        public DbSet<Category> Categories { get; set; } //list of categories for category entity refered as dbset

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)  //paramaterized_constructor //only one contextclass is allowed in a project //called duringexecution
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //onconfiruring method is used to configure the database  //called during migration
        {
            optionsBuilder.UseSqlServer("data source=MEGHANA;database=kanini;integrated security=true;trustservercertificate=true;");

        }

    }
}
