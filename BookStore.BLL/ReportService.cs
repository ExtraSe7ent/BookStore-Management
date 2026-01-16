using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace BookStore.BLL
{
    public class ReportService : IReportService
    {
        private readonly BookStoreContext _context;

        public ReportService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<RevenueReport>> GetRevenueByDateAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.Invoices
                .Where(i => i.Date >= fromDate && i.Date <= toDate)
                .GroupBy(i => i.Date.Date) 
                .Select(g => new RevenueReport
                {
                    Date = g.Key,
                    TotalRevenue = g.Sum(i => i.TotalAmount),
                    TransactionCount = g.Count()
                })
                .OrderBy(r => r.Date)
                .ToListAsync();
        }

        public async Task<dynamic> GetTopSellingBooksAsync()
        {
            return await _context.InvoiceDetails
                .Include(d => d.Book)
                .GroupBy(d => d.Book.Title)
                .Select(g => new
                {
                    BookTitle = g.Key,
                    TotalSold = g.Sum(x => x.Quantity),
                    TotalRevenue = g.Sum(x => x.Quantity * x.UnitPrice)
                })
                .OrderByDescending(x => x.TotalSold)
                .Take(5) 
                .ToListAsync();
        }

        public async Task<List<BookRevenueDto>> GetBookRevenueReportAsync(DateTime? fromDate, DateTime? toDate)
        {
            var query = _context.InvoiceDetails.AsQueryable();

            if (fromDate.HasValue)
                query = query.Where(d => d.Invoice.Date >= fromDate.Value);

            if (toDate.HasValue)
            {
                var actualToDate = toDate.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(d => d.Invoice.Date <= actualToDate);
            }

            var result = await query
                .Include(d => d.Book)
                .ThenInclude(b => b.Category)
                .GroupBy(d => new { d.Book.Title, d.Book.Category.CategoryName })
                .Select(g => new BookRevenueDto
                {
                    BookTitle = g.Key.Title,
                    Genre = g.Key.CategoryName,
                    TotalSold = g.Sum(x => x.Quantity),
                    TotalRevenue = g.Sum(x => x.Quantity * x.UnitPrice)
                })
                .OrderByDescending(x => x.TotalRevenue)
                .ToListAsync();

            return result;
        }
    }
}