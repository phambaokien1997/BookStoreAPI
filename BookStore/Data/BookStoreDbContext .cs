using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //decimal
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    {
                        property.SetPrecision(18);
                        property.SetScale(4);
                    }
                }
            }
            //Book-Author
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(ba => ba.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
            //Book-Genre
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(bg => bg.BookGenres)
                .HasForeignKey(bg => bg.BookId);
            modelBuilder.Entity<BookGenre>()
                .HasOne(pg => pg.Genre)
                .WithMany(pg => pg.BookGenres)
                .HasForeignKey(pg => pg.GenreId);
            //Book-Publisher
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);
            //Book-Order
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.BookId, od.OrderId });
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Book)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(od => od.BookId);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(od => od.OrderId);
            //Author-Genre
            modelBuilder.Entity<Genre>()
                .HasOne(g => g.Author)
                .WithMany(a => a.Genres)
                .HasForeignKey(g => g.AuthorId);
            //Customer - Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}
