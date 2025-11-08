using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ManagebookController : Controller  // Capital M!
    {
        public IActionResult Index()
        {
            Book b = new Book();
            b.Id = 1;
            b.Name = "My First Book";
            b.Description = "This is a test book.";
            b.SetInventory(10);
            return View(b);
        }
    }
}