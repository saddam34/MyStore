using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string CategoryName { get; set; }
    }
}