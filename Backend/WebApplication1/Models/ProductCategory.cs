using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ProductCategory
    {
        [Key, Column(Order = 0)]
        public int ProductID { get; set; }

        [Key, Column(Order = 1)]
        public int CategoryID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; } = null!;

        [ForeignKey("CategoryID")]
        public Category Category { get; set; } = null!;
    }
}
