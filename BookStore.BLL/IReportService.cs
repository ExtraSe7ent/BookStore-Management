using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.BLL
{
    public class BookRevenueDto
    {
        public string BookTitle { get; set; }
        public string Genre { get; set; }
        public int TotalSold { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public interface IReportService
    {
        Task<List<RevenueReport>> GetRevenueByDateAsync(DateTime fromDate, DateTime toDate);

        Task<dynamic> GetTopSellingBooksAsync();

        Task<List<BookRevenueDto>> GetBookRevenueReportAsync(DateTime? fromDate, DateTime? toDate);
    }
}