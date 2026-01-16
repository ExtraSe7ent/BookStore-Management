using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public class CustomerService : ICustomerService
    {
        private readonly BookStoreContext _context;

        public CustomerService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
                .OrderByDescending(c => c.CustomerID)
                .ToListAsync(); 
        }

        public async Task<List<Customer>> SearchCustomerAsync(string keyword)
        {
            return await _context.Customers
                .Where(c => c.FullName.Contains(keyword) || c.Phone.Contains(keyword))
                .ToListAsync(); 
        }

        public async Task AddCustomerAsync(Customer c)
        {
            if (await _context.Customers.AnyAsync(x => x.Phone == c.Phone))
                throw new Exception($"Số điện thoại {c.Phone} đã tồn tại!");

            await _context.Customers.AddAsync(c); 
            await _context.SaveChangesAsync();    
        }

        public async Task UpdateCustomerAsync(Customer c)
        {
            var existing = await _context.Customers.FindAsync(c.CustomerID);
            if (existing != null)
            {
                existing.FullName = c.FullName;
                existing.Phone = c.Phone;
                existing.Address = c.Address;

                await _context.SaveChangesAsync(); 
            }
            else
            {
                throw new Exception("Không tìm thấy khách hàng cần sửa!");
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            if (await _context.Invoices.AnyAsync(i => i.CustomerID == id))
            {
                throw new Exception("Không thể xóa khách hàng này vì họ đã có lịch sử mua hàng!");
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer); 
                await _context.SaveChangesAsync();   
            }
            else
            {
                throw new Exception("Khách hàng không tồn tại!");
            }
        }
    }
}