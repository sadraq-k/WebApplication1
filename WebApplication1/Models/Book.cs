namespace WebApplication1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }

        // Navigation property - one book can have many requests
        public List<BookRequest> BookRequests { get; set; }

        public void SetInventory(int count)
        {
            if (count >= 0 && count <= 1000)
            {
                Inventory = count;
            }
            else
            {
                Inventory = 0;
            }
        }

        public string GetInfo()
        {
            return "ID: " + Id + ", Name: " + Name + ", Description: " + Description + ", Inventory: " + Inventory;
        }
    }
}