using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class MyDBcontext : DbContext
    {
        /*این دو نقطه بیس ئه میگه اقا جون این متغیر اپشن را که ساختی حالا بفرستش برای کلاس پدر  برو توو کلاس
         پدر مقدار دهی اولیه را انجام بده*/
        public MyDBcontext(DbContextOptions<MyDBcontext> options) : base(options)
        {

        }
        // DbSet = جداول دیتابیس ما
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookRequest> BookRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships (Many-to-Many through BookRequest)
            modelBuilder.Entity<BookRequest>()
                .HasOne(br => br.Book)
                .WithMany(b => b.BookRequests)
                .HasForeignKey(br => br.BookId);

            modelBuilder.Entity<BookRequest>()
                .HasOne(br => br.Customer)
                .WithMany(c => c.BookRequests)
                .HasForeignKey(br => br.CustomerId);

            // Add some initial data (Seed data)
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Harry Potter", Description = "Magic book", Inventory = 15 },
                new Book { Id = 2, Name = "Lord of the Rings", Description = "Fantasy epic", Inventory = 8 },
                new Book { Id = 3, Name = "1984", Description = "Dystopian novel", Inventory = 12 },
                new Book { Id = 4, Name = "Pride and Prejudice", Description = "Romance classic", Inventory = 5 },
                new Book { Id = 5, Name = "The Hobbit", Description = "Adventure tale", Inventory = 20 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Ali Ahmadi", Age = 25, Address = "Isfahan" },
                new Customer { Id = 2, Name = "Sara Rezaei", Age = 15, Address = "Isfahan" },
                new Customer { Id = 3, Name = "Reza Karimi", Age = 30, Address = "Tehran" },
                new Customer { Id = 4, Name = "Mina Hosseini", Age = 12, Address = "Isfahan" },
                new Customer { Id = 5, Name = "Mohammad Jafari", Age = 8, Address = "Shiraz" }
            );

            modelBuilder.Entity<BookRequest>().HasData(
                new BookRequest { Id = 1, BookId = 1, CustomerId = 1, RequestDate = new DateTime(2025, 1, 10) },
                new BookRequest { Id = 2, BookId = 2, CustomerId = 1, RequestDate = new DateTime(2025, 1, 12) },
                new BookRequest { Id = 3, BookId = 1, CustomerId = 2, RequestDate = new DateTime(2025, 2, 1) },
                new BookRequest { Id = 4, BookId = 3, CustomerId = 3, RequestDate = new DateTime(2025, 2, 5) },
                new BookRequest { Id = 5, BookId = 5, CustomerId = 4, RequestDate = new DateTime(2025, 3, 10) }
                );

        }
    }
}

