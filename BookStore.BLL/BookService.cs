using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BLL
{
    public class BookService : IBookService
    {
        private readonly BookStoreContext _context;

        public BookService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .OrderByDescending(b => b.BookID)
                .ToListAsync(); 
        }

        public async Task<List<Book>> SearchBooksAsync(string keyword)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.Title.Contains(keyword) || b.Author.AuthorName.Contains(keyword))
                .ToListAsync(); 
        }

        public async Task AddBookAsync(Book book)
        {
            if (await _context.Books.AnyAsync(b => b.Title == book.Title))
                throw new Exception("Tên sách này đã tồn tại trong kho!");

            await _context.Books.AddAsync(book); 
            await _context.SaveChangesAsync();   
        }

        public async Task UpdateBookAsync(Book book)
        {
            var existing = await _context.Books.FindAsync(book.BookID);

            if (existing != null)
            {
                existing.Title = book.Title;
                existing.AuthorID = book.AuthorID;
                existing.PublisherID = book.PublisherID;
                existing.CategoryID = book.CategoryID;
                existing.Price = book.Price;
                existing.Stock = book.Stock;

                await _context.SaveChangesAsync(); 
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            if (await _context.InvoiceDetails.AnyAsync(d => d.BookID == id))
                throw new Exception("Sách này đã có trong lịch sử giao dịch, không thể xóa!");

            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                _context.Books.Remove(book); 
                await _context.SaveChangesAsync(); 
            }
        }
    }
}