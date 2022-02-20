using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MyStore.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "ProductId")]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Required")]
        public string ProductName { get; set; }

        [Display(Name = "Category Type")]
        [Required(ErrorMessage = "Required")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }

    public class ProductDB : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}