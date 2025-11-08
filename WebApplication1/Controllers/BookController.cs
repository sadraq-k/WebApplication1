using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        // Your existing Show method
        public IActionResult Show()
        {
            Book b = new Book();
            b.Id = 1;
            b.Name = "My First Book";
            b.Description = "This is a test book.";
            b.SetInventory(10);
            return View(b);
        }

        
        public IActionResult Report()
        {
            List<Book> allBooks = new List<Book>();

            Book b1 = new Book();
            b1.Id = 1;
            b1.Name = "Harry Potter";
            b1.Description = "Magic and stuff";
            b1.SetInventory(5);
            allBooks.Add(b1);

            Book b2 = new Book();
            b2.Id = 2;
            b2.Name = "Lord of the Rings";
            b2.Description = "Hobbits and rings";
            b2.SetInventory(3);
            allBooks.Add(b2);

            Book b3 = new Book();
            b3.Id = 3;
            b3.Name = "Out of Stock Book 1";
            b3.Description = "Sorry, none left";
            b3.SetInventory(0);
            allBooks.Add(b3);

            Book b4 = new Book();
            b4.Id = 4;
            b4.Name = "Out of Stock Book 2";
            b4.Description = "All sold out";
            b4.SetInventory(0);
            allBooks.Add(b4);

            Book b5 = new Book();
            b5.Id = 5;
            b5.Name = "Out of Stock Book 3";
            b5.Description = "Come back later";
            b5.SetInventory(0);
            allBooks.Add(b5);

            return View(allBooks);
        }
    }
}