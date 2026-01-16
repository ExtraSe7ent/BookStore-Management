using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BLL
{
    public class PublisherService : IPublisherService
    {
        private readonly BookStoreContext _context;

        public PublisherService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _context.Publishers
                .OrderBy(p => p.PublisherName)
                .ToListAsync(); 
        }

        public async Task AddPublisherAsync(Publisher publisher)
        {
            if (await _context.Publishers.AnyAsync(p => p.PublisherName == publisher.PublisherName))
            {
                throw new Exception("Tên Nhà xuất bản này đã tồn tại!");
            }

            await _context.Publishers.AddAsync(publisher); 
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdatePublisherAsync(Publisher publisher)
        {
            var existing = await _context.Publishers.FindAsync(publisher.PublisherID);
            if (existing != null)
            {
                existing.PublisherName = publisher.PublisherName;
                existing.Address = publisher.Address;
                await _context.SaveChangesAsync(); 
            }
            else
            {
                throw new Exception("Không tìm thấy Nhà xuất bản để cập nhật!");
            }
        }

        public async Task DeletePublisherAsync(int id)
        {
            if (await _context.Books.AnyAsync(b => b.PublisherID == id))
            {
                throw new Exception("Không thể xóa NXB này vì đang có sách thuộc về họ trong hệ thống!");
            }

            var existing = await _context.Publishers.FindAsync(id);
            if (existing != null)
            {
                _context.Publishers.Remove(existing); 
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Nhà xuất bản không tồn tại!");
            }
        }
    }
}