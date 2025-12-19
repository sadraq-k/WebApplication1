using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarController : Controller
    {
        private readonly MyDBcontext _context;

        public CarController(MyDBcontext context)
        {
            _context = context;
        }

        // GET: Show the car registration form
        public IActionResult Register()
        {
            return View();
        }

        // POST: Save the car to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Cars.Add(car);
                    _context.SaveChanges();

                    ViewBag.Message = $"Car '{car.CarName}' registered successfully for owner '{car.OwnerName}'!";
                    ModelState.Clear(); // Clear form after successful save
                    return View(new Car()); // Return empty form
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error saving car: " + ex.Message;
            }

            return View(car);
        }

        // Show list of all cars
        public IActionResult List()
        {
            var cars = _context.Cars.OrderByDescending(c => c.CarId).ToList();
            return View(cars);
        }
    }
}