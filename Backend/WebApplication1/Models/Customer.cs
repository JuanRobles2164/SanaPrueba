using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public string LastName { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
