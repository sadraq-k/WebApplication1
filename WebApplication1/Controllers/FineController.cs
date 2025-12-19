using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FineController : Controller
    {
        private readonly MyDBcontext _context;

        public FineController(MyDBcontext context)
        {
            _context = context;
        }

        // GET: Show the fine registration form
        public IActionResult Register()
        {
            ViewBag.Cars = _context.Cars.OrderBy(c => c.CarName).ToList();
            return View();
        }

        // POST: Save the fine to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Fine fine)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Fines.Add(fine);
                    _context.SaveChanges();

                    var car = _context.Cars.Find(fine.CarId);
                    ViewBag.Message = $"Fine of {fine.FineAmount:N0} Rials registered successfully for {car?.CarName}!";

                    ModelState.Clear(); // Clear form
                    ViewBag.Cars = _context.Cars.OrderBy(c => c.CarName).ToList();
                    return View(new Fine()); // Return empty form
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error saving fine: " + ex.Message;
            }

            ViewBag.Cars = _context.Cars.OrderBy(c => c.CarName).ToList();
            return View(fine);
        }

        // GET: Show the search form
        public IActionResult Search()
        {
            return View();
        }

        // POST: Search fines by owner name
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string ownerName)
        {
            if (string.IsNullOrEmpty(ownerName))
            {
                ViewBag.Message = "Please enter an owner name.";
                return View();
            }

            // Find all fines for cars owned by this person
            var fines = _context.Fines
                .Include(f => f.Car)
                .Where(f => f.Car.OwnerName.ToLower() == ownerName.ToLower())
                .OrderByDescending(f => f.FineDate)
                .ToList();

            if (fines.Count == 0)
            {
                ViewBag.Message = $"No fines found for owner '{ownerName}'.";
            }

            ViewBag.OwnerName = ownerName;
            return View(fines);
        }
    }
}