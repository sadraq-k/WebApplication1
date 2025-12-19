using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Fine
    {
        public int FineId { get; set; }

        [Required(ErrorMessage = "Fine date is required")]
        public DateTime FineDate { get; set; }

        [Required(ErrorMessage = "Fine amount is required")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FineAmount { get; set; }

        // Foreign key
        [Required(ErrorMessage = "Car is required")]
        public int CarId { get; set; }

        // Navigation property - each fine belongs to one car
        public Car Car { get; set; }
    }
}