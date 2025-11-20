using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReportsController : Controller
    {
        private readonly MyDBcontext _context;

        // Dependency Injection - دیتابیس را اینجا دریافت می‌کنیم
        public ReportsController(MyDBcontext context)
        {
            _context = context;
        }

        // Report 1: لیست تمام کتاب‌ها
        public IActionResult AllBooks()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        // Report 2: لیست کتاب‌هایی که موجودی بیشتر از 10 دارند
        public IActionResult BooksWithHighInventory()
        {
            var books = _context.Books
                .Where(b => b.Inventory > 10)
                .ToList();
            return View(books);
        }

        // Report 3: لیست مشتریان بالای 10 سال که در اصفهان هستند
        public IActionResult IsfahanCustomers()
        {
            var customers = _context.Customers
                .Where(c => c.Age > 10 && c.Address == "Isfahan")
                .ToList();
            return View(customers);
        }

        // Bonus: لیست تمام مشتریان
        public IActionResult AllCustomers()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // Bonus: لیست تمام درخواست‌ها با اطلاعات کتاب و مشتری
        public IActionResult AllRequests()
        {
            var requests = _context.BookRequests
                .Include(br => br.Book)        // Join with Books table
                .Include(br => br.Customer)    // Join with Customers table
                .ToList();
            return View(requests);
        }
    }
}