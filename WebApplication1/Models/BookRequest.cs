namespace WebApplication1.Models
{
    public class BookRequest
    {
        public int Id { get; set; }

        // Foreign keys
        public int BookId { get; set; }
        public int CustomerId { get; set; }

        // Navigation properties
        public Book Book { get; set; }
        public Customer Customer { get; set; }

        // Optional: add request date
        public DateTime RequestDate { get; set; }
    }
}