using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller  
    {
        public string Index(string Id)
        {
            return "This is the blog index page.:" + Id;
        }

        public string Show()
        {
            return "Hello world";
        }
    }
}