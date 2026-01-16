using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace BookStore.DAL
{
    public class BookStoreContext : DbContext
    {
        // 1. KHAI BÁO CÁC BẢNG 
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }


        // 2. CẤU HÌNH MODEL & SEED DATA
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- A. CẤU HÌNH KIỂU DỮ LIỆU & RÀNG BUỘC  ---

            modelBuilder.Entity<Book>().Property(b => b.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Invoice>().Property(i => i.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<InvoiceDetail>().Property(d => d.UnitPrice).HasColumnType("decimal(18,2)");

            // --- CẤU HÌNH QUAN HỆ (RELATIONSHIPS) ---

            // 1. Invoice - User (Nhân viên):
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // 2. Invoice - Customer (Khách hàng):
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. Invoice - InvoiceDetail:
            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(d => d.Invoice)
                .WithMany(i => i.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceID)
                .OnDelete(DeleteBehavior.Cascade);

            // 4. Book - Các bảng cha (Author, Publisher, Category)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID)
                .OnDelete(DeleteBehavior.Restrict);


            // --- B. DỮ LIỆU MẪU ---

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, RoleName = "Admin" },
                new Role { RoleID = 2, RoleName = "Staff" }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    FullName = "Administrator",
                    UserName = "admin",
                    Password = "123",
                    RoleID = 1,
                    IsActive = true
                },
                new User
                {
                    UserID = 2,
                    FullName = "Nhân viên Bán hàng A",
                    UserName = "staff",
                    Password = "123",
                    RoleID = 2,
                    IsActive = true
                }
            );

            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory { CategoryID = 1, CategoryName = "Sách Giáo Khoa" },
                new BookCategory { CategoryID = 2, CategoryName = "Tiểu Thuyết & Văn Học" },
                new BookCategory { CategoryID = 3, CategoryName = "Kinh Tế & Quản Trị" },
                new BookCategory { CategoryID = 4, CategoryName = "Công Nghệ Thông Tin" },
                new BookCategory { CategoryID = 5, CategoryName = "Truyện Tranh (Manga)" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorID = 1, AuthorName = "Nguyễn Nhật Ánh", BirthYear = 1955 },
                new Author { AuthorID = 2, AuthorName = "J.K. Rowling", BirthYear = 1965 },
                new Author { AuthorID = 3, AuthorName = "Nam Cao", BirthYear = 1915 },
                new Author { AuthorID = 4, AuthorName = "Robert C. Martin", BirthYear = 1952 }, 
                new Author { AuthorID = 5, AuthorName = "Fujiko F. Fujio", BirthYear = 1933 }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherID = 1, PublisherName = "NXB Trẻ", Address = "161B Lý Chính Thắng, TP.HCM" },
                new Publisher { PublisherID = 2, PublisherName = "NXB Kim Đồng", Address = "55 Quang Trung, Hà Nội" },
                new Publisher { PublisherID = 3, PublisherName = "NXB Giáo Dục", Address = "81 Trần Hưng Đạo, Hà Nội" },
                new Publisher { PublisherID = 4, PublisherName = "O'Reilly Media", Address = "USA" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookID = 1,
                    Title = "Mắt Biếc",
                    AuthorID = 1, 
                    CategoryID = 2, 
                    PublisherID = 1, 
                    Price = 110000,
                    Stock = 50
                },
                new Book
                {
                    BookID = 2,
                    Title = "Harry Potter và Hòn Đá Phù Thủy",
                    AuthorID = 2, 
                    CategoryID = 2,
                    PublisherID = 1,
                    Price = 250000,
                    Stock = 100
                },
                new Book
                {
                    BookID = 3,
                    Title = "Clean Code (Mã Sạch)",
                    AuthorID = 4, 
                    CategoryID = 4, 
                    PublisherID = 4, 
                    Price = 450000,
                    Stock = 20
                },
                new Book
                {
                    BookID = 4,
                    Title = "Doraemon Tập 1",
                    AuthorID = 5,
                    CategoryID = 5, 
                    PublisherID = 2, 
                    Price = 25000,
                    Stock = 200
                },
                new Book
                {
                    BookID = 5,
                    Title = "Tiếng Việt Lớp 1",
                    AuthorID = 3, 
                    CategoryID = 1,
                    PublisherID = 3, 
                    Price = 15000,
                    Stock = 500
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, FullName = "Khách Vãng Lai", Phone = "0000000000", Address = "N/A" },
                new Customer { CustomerID = 2, FullName = "Trần Văn A", Phone = "0909123456", Address = "Hà Nội" },
                new Customer { CustomerID = 3, FullName = "Lê Thị B", Phone = "0918123456", Address = "Đà Nẵng" }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    InvoiceID = 1,
                    Date = DateTime.Now.AddDays(-1), 
                    CustomerID = 2, 
                    UserID = 2, 
                    TotalAmount = 160000 
                }
            );

            modelBuilder.Entity<InvoiceDetail>().HasData(
                new InvoiceDetail
                {
                    DetailID = 1,
                    InvoiceID = 1,
                    BookID = 1,
                    Quantity = 1,
                    UnitPrice = 110000
                },
                new InvoiceDetail
                {
                    DetailID = 2,
                    InvoiceID = 1,
                    BookID = 4,
                    Quantity = 2,
                    UnitPrice = 25000
                }
            );
        }
    }
}