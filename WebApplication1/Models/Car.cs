using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [Required(ErrorMessage = "Car name is required")]
        public string CarName { get; set; }

        [Required(ErrorMessage = "Owner name is required")]
        public string OwnerName { get; set; }

        // Navigation property - one car can have many fines
        public List<Fine> Fines { get; set; }
    }
}