using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public class InvoiceService : IInvoiceService
    {
        private readonly BookStoreContext _context;

        public InvoiceService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task CreateInvoiceAsync(Invoice invoice, List<InvoiceDetail> details)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    decimal finalTotal = 0;

                    await _context.Invoices.AddAsync(invoice);
                    await _context.SaveChangesAsync(); 

                    foreach (var item in details)
                    {
                        item.InvoiceID = invoice.InvoiceID;

                        var bookInDb = await _context.Books.FindAsync(item.BookID);
                        if (bookInDb == null) throw new Exception("Sách không tồn tại!");

                        if (bookInDb.Stock < item.Quantity)
                            throw new Exception($"Sách '{bookInDb.Title}' không đủ hàng! (Còn: {bookInDb.Stock})");

                        bookInDb.Stock -= item.Quantity;

                        item.UnitPrice = bookInDb.Price;
                        finalTotal += (item.Quantity * item.UnitPrice);

                        await _context.InvoiceDetails.AddAsync(item);
                    }

                    invoice.TotalAmount = finalTotal;

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<dynamic> GetInvoiceHistoryAsync()
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.User)
                .OrderByDescending(i => i.Date)
                .Select(i => new
                {
                    i.InvoiceID,
                    Date = i.Date,
                    CustomerName = i.Customer.FullName,
                    StaffName = i.User.FullName,
                    Total = i.TotalAmount
                })
                .ToListAsync();
        }

        public async Task<dynamic> GetInvoiceDetailsAsync(int invoiceId)
        {
            return await _context.InvoiceDetails
                .Include(d => d.Book)
                .Where(d => d.InvoiceID == invoiceId)
                .Select(d => new
                {
                    BookTitle = d.Book.Title,
                    Qty = d.Quantity,
                    Price = d.UnitPrice,
                    Total = d.Quantity * d.UnitPrice
                })
                .ToListAsync();
        }
    }
}