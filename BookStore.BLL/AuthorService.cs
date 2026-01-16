using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public class AuthorService : IAuthorService
    {
        private readonly BookStoreContext _context;

        public AuthorService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors
                .OrderBy(a => a.AuthorName)
                .ToListAsync(); 
        }

        public async Task AddAuthorAsync(Author author)
        {
            if (await _context.Authors.AnyAsync(a => a.AuthorName == author.AuthorName))
            {
                throw new Exception("Tên tác giả này đã tồn tại!");
            }

            await _context.Authors.AddAsync(author); 
            await _context.SaveChangesAsync();       
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            var existing = await _context.Authors.FindAsync(author.AuthorID);

            if (existing != null)
            {
                existing.AuthorName = author.AuthorName;
                existing.BirthYear = author.BirthYear;

                await _context.SaveChangesAsync(); 
            }
            else
            {
                throw new Exception("Không tìm thấy tác giả để cập nhật!");
            }
        }

        public async Task DeleteAuthorAsync(int id)
        {
            if (await _context.Books.AnyAsync(b => b.AuthorID == id))
            {
                throw new Exception("Không thể xóa tác giả này vì họ đang có sách trong hệ thống!");
            }

            var existing = await _context.Authors.FindAsync(id);

            if (existing != null)
            {
                _context.Authors.Remove(existing); 
                await _context.SaveChangesAsync(); 
            }
        }
    }
}