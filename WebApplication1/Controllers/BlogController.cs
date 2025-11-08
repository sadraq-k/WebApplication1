using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller  
    {
        public string Index()
        {
            return "This is the blog index page.";
        }

        public string Show()
        {
            return "Hello world";
        }
    }
}