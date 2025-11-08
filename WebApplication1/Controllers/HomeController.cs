using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


/*this folder (controllers) it's between veiw and models connect them to each auther with 
 controllers :) */
/*به ازای هر صفحه اینحا یک تابع داریم مثلا ویو پرایوسی و ویو ایندکس */
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /*اقا ما اینجا داریم به دات نت کور می گیم که اقا جون ما یه صفحه ی دیگه به اسم هیدن داریم 
           حواست باشه اسمشا دیدی اینا چاپ کن این را به عنوان یک صفه زیر مجموعه هوم میشناسه*/
        public string getUser()
        {
            /*الان اون طرف توو مدل کلاس یا مدل یوزر را تعریف کردیم و حالا اومدیم اینجا از این 
             مدل استفاده می کنیم الان که یه دونه نیو کردیم از این یعن یه متغیر یوزر بساز :) */
            
            User user = new User();
            user.Id = 1;
            user.Username = "admin";
            user.Password = "1234";
            return "only they knows :" + user.Username;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
