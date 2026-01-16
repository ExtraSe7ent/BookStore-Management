using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly BookStoreContext _context;

        public CategoryService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<BookCategory>> GetAllAsync()
        {
            return await _context.BookCategories.ToListAsync(); 
        }

        public async Task AddCategoryAsync(BookCategory category)
        {
            if (await _context.BookCategories.AnyAsync(c => c.CategoryName == category.CategoryName))
                throw new Exception("Tên thể loại đã tồn tại!");

            await _context.BookCategories.AddAsync(category); 
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateCategoryAsync(BookCategory category)
        {
            var existing = await _context.BookCategories.FindAsync(category.CategoryID);
            if (existing != null)
            {
                existing.CategoryName = category.CategoryName;
                await _context.SaveChangesAsync(); 
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            if (await _context.Books.AnyAsync(b => b.CategoryID == id))
                throw new Exception("Không thể xóa thể loại đang có sách!");

            var item = await _context.BookCategories.FindAsync(id);
            if (item != null)
            {
                _context.BookCategories.Remove(item); 
                await _context.SaveChangesAsync(); 
            }
        }
    }
}