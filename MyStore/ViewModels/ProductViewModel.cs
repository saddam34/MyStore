using MyStore.Models;
using System.Collections.Generic;

namespace MyStore.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public Product Product { get; set; }
    }
}